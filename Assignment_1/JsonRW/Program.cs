using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonRW
{
    class Program
    {
        private const string path = @"F:\BCT_Training\JsonFile.json.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Question 5(a):-");
            Console.WriteLine();
            //Parsing Json Lab
            using (StreamReader r = new StreamReader(path))
            {
                string jsonString = r.ReadToEnd();
                JObject ob = JObject.Parse(jsonString);
                var labsArray = JArray.Parse(ob["labs"].ToString());
                
                Dictionary<string, string> dLabs = new Dictionary<string, string>();
 
                foreach (var jTokenLabs in labsArray)
                {
                    if (jTokenLabs["time"].ToString().Equals("Today"))
                    {
                        dLabs.Add(jTokenLabs["name"].ToString(), jTokenLabs["location"].ToString());
                    }
                }
                foreach (KeyValuePair<string, string> labTemp in dLabs)
                {
                    Console.WriteLine("Name of Lab : {0}, Location of Lab : {1}",
                        labTemp.Key, labTemp.Value);
                }
            }
            
            Console.WriteLine();
            Console.WriteLine("Question 5(b):-");
            Console.WriteLine();
            //Deserializing Json
            var fileContent = File.ReadAllText(path);
            dynamic dynObj = JsonConvert.DeserializeObject<dynamic>(fileContent);
            Dictionary<string, string> dMeds = new Dictionary<string, string>();
            foreach (var meds in dynObj.medications)
            {
                foreach (var data1 in meds.aceInhibitors)
                {
                    if (data1.route.ToString().Equals("PO"))
                        dMeds.Add(data1.name.ToString(), data1.strength.ToString());
                }
                foreach (var data2 in meds.antianginal)
                {
                    if (data2.route.ToString().Equals("PO"))
                        dMeds.Add(data2.name.ToString(), data2.strength.ToString());
                }
                foreach (var data3 in meds.anticoagulants)
                {
                    if (data3.route.ToString().Equals("PO"))
                        dMeds.Add(data3.name.ToString(), data3.strength.ToString());
                }
                foreach (var data4 in meds.betaBlocker)
                {
                    if (data4.route.ToString().Equals("PO"))
                        dMeds.Add(data4.name.ToString(), data4.strength.ToString());
                }
                foreach (var data5 in meds.diuretic)
                {
                    if (data5.route.ToString().Equals("PO"))
                        dMeds.Add(data5.name.ToString(), data5.strength.ToString());
                }
                foreach (var data6 in meds.mineral)
                {
                    if (data6.route.ToString().Equals("PO"))
                        dMeds.Add(data6.name.ToString(), data6.strength.ToString());
                }
            }
            foreach (KeyValuePair<string, string> medicationTemp in dMeds)
            {
                Console.WriteLine("Name of Medication : {0}, Strength of Medication : {1}",
                    medicationTemp.Key, medicationTemp.Value);
            }
        }
    }
}
