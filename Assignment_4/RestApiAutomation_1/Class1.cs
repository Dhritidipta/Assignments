using NUnit.Framework;
using RestSharp;
using System;

namespace RestApiAutomation_1
{
    [TestFixture]
    public class Class1
    {
        IRestClient client = new RestClient("https://reqres.in/api");

        [Test]
        public void GetUsersByPage()
        {
            IRestRequest request = new RestRequest("/users?page=2");
            IRestResponse response = client.Get(request);
            Console.WriteLine((int)response.StatusCode); 
        }

        [Test]
        public void GetUsersById()
        {
            IRestRequest request2 = new RestRequest("/users/2", Method.GET);
            var response2 = client.Execute(request2);
            Console.WriteLine((int)response2.StatusCode);
        }

        [Test]
        public void GetUsersByInvalidId()
        {
            IRestRequest request3 = new RestRequest("/users/1", Method.GET);
            var response3 = client.Execute(request3);
            Console.WriteLine((int)response3.StatusCode);
            Console.WriteLine(response3.Content);
        }

        
        [Test]
        public void GetListResource()
        {
            IRestRequest request4 = new RestRequest("/unknown", Method.GET);
            var response4 = client.Execute(request4);
            Console.WriteLine((int)response4.StatusCode);
            Console.WriteLine(response4.Content);
        }
        [Test]
        public void GetSingleResource()
        {
            IRestRequest request5 = new RestRequest("/unknown/2", Method.GET);
            var response5 = client.Execute(request5);
            Console.WriteLine((int)response5.StatusCode);
            Console.WriteLine(response5.Content);
        }
        [Test]
        public void GetInvalidResource()
        {
            IRestRequest request6 = new RestRequest("/unknown/23", Method.GET);
            var response6 = client.Execute(request6);
            Console.WriteLine((int)response6.StatusCode);
        }
    }
}
