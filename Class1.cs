using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json;
using LuisBot;
namespace LuisBot
{
    public class BankData
    {
        public static object GetBankData(string name)
        {
            try
            {
                // DataTable dtBankDetails = new DataTable();
                // string jsonResult;
                //DataTable jsonResult = new DataTable();

                using (var client = new WebClient()) //WebClient  
                {
                    client.Headers.Add("Content-Type:application/json"); //Content-Type  
                    client.Headers.Add("Accept:application/json");

                    var json = client.DownloadString("http://api.tvmaze.com/singlesearch/shows?q=" + name);

                    // var jsonDynamic = System.Web.Helpers.Json.Decode(json);
                    var item = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                    return item;

                }



            }
            catch
            {

                return null;
            }

        }
        
    }
}
