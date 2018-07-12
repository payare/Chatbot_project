using System.Net;
using LuisBot.Dialogs;

namespace BankChatBot
{
    public class BankData
    {
        public static object GetBankData(string IFSCCode)
        {
            try
            {
                using (var client = new WebClient()) //WebClient  
                {
                    client.Headers.Add("Content-Type:application/json"); //Content-Type  
                    client.Headers.Add("Accept:application/json");
                    var json = client.DownloadString("https://api.railwayapi.com/v2/name-number/train/" + IFSCCode + "/apikey/c3prk0pp13/");
                    var item = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                    //if (result.TryFindEntity(EntityTrainCode, out trainEntityRecommendation))
                    //{

                    //}
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