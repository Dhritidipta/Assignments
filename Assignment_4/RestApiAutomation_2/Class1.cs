using NUnit.Framework;
using RestApiAutomation_2.DTOs.GetPostsObject;
using RestApiAutomation_2.DTOs.CreatePost;
using RestApiAutomation_2.DTOs.UpdatePosts;
using RestSharp;
using System;
using System.Collections.Generic;

namespace RestApiAutomation_2
{
    [TestFixture]
    class Class1
    {
        readonly IRestClient client = new RestClient("https://jsonplaceholder.typicode.com");

        [Test]
        public void GetAllPosts()
        {
            IRestRequest request = new RestRequest("/posts", Method.GET);
            request.AddHeader("Content-type", "application/json");
            IRestResponse<List<GetPostsResponse>> response = client.Execute<List<GetPostsResponse>>(request);
            if (response.IsSuccessful)
            {
                Console.WriteLine((int)response.StatusCode);

                foreach (GetPostsResponse data in response.Data)
                {
                    Console.WriteLine("UserId: " + data.UserId);
                    Console.WriteLine("Id: " + data.Id);
                    Console.WriteLine("Title: " + data.Title);
                    Console.WriteLine("Body: " + data.Body);
                    Console.WriteLine("--------------------------------------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
                Console.WriteLine(response.ErrorException);
            }
        }

        [Test]
        public void GetPostById()
        {
            IRestRequest request = new RestRequest("/posts/{Id}", Method.GET);
            request.AddUrlSegment("Id", "1");
            request.AddHeader("Content-type", "application/json");
            IRestResponse<GetPostsResponse> response = client.Execute<GetPostsResponse>(request);
            if (response.IsSuccessful)
            {
                Console.WriteLine((int)response.StatusCode);
                Console.WriteLine("UserId: " + response.Data.UserId);
                Console.WriteLine("Id: " + response.Data.Id);
                Console.WriteLine("Title: " + response.Data.Title);
                Console.WriteLine("Body: " + response.Data.Body);
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
                Console.WriteLine(response.ErrorException);
            }
        }

        [Test]
        public void GetAllPostsInSingleUserId()
        {
            IRestRequest request = new RestRequest("/users/{UserId}/posts", Method.GET);
            request.AddUrlSegment("UserId", "2");
            request.AddHeader("Accept", "application/json");
            IRestResponse<List<GetPostsResponse>> response = client.Execute<List<GetPostsResponse>>(request);
            if (response.IsSuccessful)
            {
                Console.WriteLine((int)response.StatusCode);

                foreach (GetPostsResponse data in response.Data)
                {
                    Console.WriteLine("UserId: " + data.UserId);
                    Console.WriteLine("Id: " + data.Id);
                    Console.WriteLine("Title: " + data.Title);
                    Console.WriteLine("Body: " + data.Body);
                    Console.WriteLine("--------------------------------------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
                Console.WriteLine(response.ErrorException);
            }
        }

        [Test]
        public void CreatePostInUserId()
        {
            var createRequest = new CreatePostRequest()
            {
                UserId = 1,
                Title = "RestSharp Assignment_2",
                Body = "RestApi Automation using RestSharp implementing in Visual Studio."
            };

            IRestRequest request = new RestRequest("/posts", Method.POST);
            request.AddJsonBody(createRequest);
            request.AddHeader("Content-type", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                Console.WriteLine((int)response.StatusCode);
                Console.WriteLine(response.Content);
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
                Console.WriteLine(response.ErrorException);
            }

        }

        [Test]
        public void UpdatePost()
        {
            var updateRequest = new UpdatePostRequest()
            {
                UserId = 1,
                Id = 2,
                Title = "RestSharp Assignment_2",
                Body = "RestApi Automation using RestSharp implementing in Visual Studio."
            };

            IRestRequest request = new RestRequest("/posts", Method.PUT);
            request.AddJsonBody(updateRequest);
            request.AddHeader("Content-type", "application/json; charset=UTF-8");
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                Console.WriteLine((int)response.StatusCode);
                Console.WriteLine(response.Content);
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
                Console.WriteLine(response.ErrorException);
            }

        }

        [Test]
        public void DeletePost()
        {
            IRestRequest request = new RestRequest("/posts/{Id}", Method.DELETE);
            request.AddUrlSegment("Id", "1");
            var response = client.Execute(request);
            Console.WriteLine((int)response.StatusCode);
        }
    }
}