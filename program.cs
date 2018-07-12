using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using Newtonsoft.Json.Linq;

namespace LuisBot
{
    public class program
    {
        private static string name;

        static void Main(string[] args)

        {

            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");


                var json = client.DownloadString("http://api.tvmaze.com/singlesearch/shows?q=" + name + "/apikey/c3prk0pp13/");
                JObject jObject = JObject.Parse(json);
                string conversion = "";
                foreach (var result1 in jObject["shows"])
                {
                    conversion = jObject["id"]["url"].ToString();
                    Console.WriteLine(conversion);
                    Console.ReadLine();
                }
            }
         }

    }
}