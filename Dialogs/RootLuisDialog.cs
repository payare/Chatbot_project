namespace LuisBot.Dialogs
{
    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Builder.FormFlow;
    using Microsoft.Bot.Builder.Luis;
    using Microsoft.Bot.Builder.Luis.Models;
    using Microsoft.Bot.Connector;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Net;
   

    [LuisModel("2202e54c-a80e-4fe8-ac20-fe5c5948c261 ", "b4373aa49bfa4c69af61cd188e8538b0")]
    [Serializable]
    public class RootLuisDialog : LuisDialog<object>
    {
        // private const string EntityChannel = "Channel";
      //  private const string EntityShow_language = "Show_language";
        private const string Entityshowname = "showname";
        private const string EntityShowdate = "Showdate";
        private const string EntityShowid = "Showid";
        private static string name;

        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {

            string message = $"How can you!!!!!!!!!!.";
            // await context.PostAsync("Welcome to the TVshow finder!");
            // await context.PostAsync("Enter TVshow name");
            await context.PostAsync(message);

            context.Wait(this.MessageReceived);

        }

         [LuisIntent("Show_name")]
        public async Task Task(IDialogContext context, LuisResult result)
        {
            EntityRecommendation showEntityRecommendation;
            string message = $"wait";
            await context.PostAsync(message);

            if (result.TryFindEntity(Entityshowname, out showEntityRecommendation))
            {
                await context.PostAsync($"Showname is Intent and Entity is'{showEntityRecommendation.Entity}'");
               // var B = GetShowData(context,result);
                //await context.PostAsync(B.ToString());
               await this.DisplayHerocard(context,showEntityRecommendation.Entity);
                //await this.DisplayAnimationcard(context, cityEntityRecommendation.Entity);
            }
        }


        public async Task DisplayHerocard(IDialogContext context, string showname)
        {
            //await context.PostAsync("Welcome to the TVshow finder!");
            var replyMessage = context.MakeMessage();
            Attachment attachment = GetProfileHeroCard(showname);
            replyMessage.Attachments = new List<Attachment> { attachment };
            await context.PostAsync(replyMessage);

        }



        private static Attachment GetProfileHeroCard(string name)
        {
            var heroCard = new HeroCard
            {

                Title = name,
                Images = new List<CardImage> { new CardImage("https://placeholdit.imgix.net/~text?txtsize=35&txt=Tvshow+{i}&w=500&h=260") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Show Information", value: "https://www.bing.com/search?q=TVshow+in+" + name + "") }
            };
            return heroCard.ToAttachment();
        }


        


        [LuisIntent("Date")]
        public async Task date(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {
            string message = $"wait";
            EntityRecommendation showEntityRecommendation;

            await context.PostAsync(message);
            if (result.TryFindEntity(EntityShowdate, out showEntityRecommendation))
            {
                await context.PostAsync($"Date is Intent and Entity is'{showEntityRecommendation.Entity}'");
               var B = GetNameData(context,result);
               //await context.PostAsync(B.ToString());

            }
        }




        [LuisIntent("ID")]
        public async Task id(IDialogContext context, LuisResult result)
        {
            EntityRecommendation showEntityRecommendation;
            string message = $" plz wait";
            await context.PostAsync(message);

            if (result.TryFindEntity(EntityShowid, out showEntityRecommendation))
            {
                await context.PostAsync($"ID is Intent and Entity is'{showEntityRecommendation.Entity}'");
               
                //await context.PostAsync(B.ToString());
                // await this.DisplayHerocard1(context, cityEntityRecommendation.Entity);
                var c = GetShowData(context, result);
            }
        }


        [LuisIntent("Information")]
        public async Task info(IDialogContext context, LuisResult result)
        {
            EntityRecommendation showEntityRecommendation;
           // string message = $"wait";
            //await context.PostAsync(message);

            if (result.TryFindEntity(Entityshowname, out showEntityRecommendation))
            {
                await context.PostAsync($"Information is Intent and Entity is'{showEntityRecommendation.Entity}'");
               var c = GetInfoData(context, result);
                //await context.PostAsync(B.ToString());
               //await this.DisplayHerocard(context, showEntityRecommendation.Entity);


            }
        }




        [LuisIntent("Schedule")]
        public async Task schedule(IDialogContext context, LuisResult result)
        {
            EntityRecommendation showEntityRecommendation;
            // string message = $"wait";
            //await context.PostAsync(message);

            if (result.TryFindEntity(Entityshowname, out showEntityRecommendation))
            {
                await context.PostAsync($"Schedule is Intent and Entity is'{showEntityRecommendation.Entity}'");
                var c = GetScheduleData(context, result);
                //await context.PostAsync(B.ToString());


            }
        }



        [LuisIntent("Rating")]
        public async Task rating(IDialogContext context, LuisResult result)
        {
            EntityRecommendation showEntityRecommendation;
            // string message = $"wait";
            //await context.PostAsync(message);

            if (result.TryFindEntity(Entityshowname, out showEntityRecommendation))
            {
                await context.PostAsync($"Rating is Intent and Entity is'{showEntityRecommendation.Entity}'");
                var c = GetRatingData(context, result);
                //await context.PostAsync(B.ToString());


            }
        }


        private async Task GetShowData(IDialogContext context, LuisResult result)

        {

            using (var client = new WebClient()) //WebClient  
            {

                EntityRecommendation showEntityRecommendation;

                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                if (result.TryFindEntity(EntityShowid, out showEntityRecommendation))
                {


                    var json = client.DownloadString("http://api.tvmaze.com/shows/" + showEntityRecommendation.Entity);
                    JObject jObject = JObject.Parse(json);
                    string conversion = "";
                    conversion = jObject["name"].ToString();
                    await context.PostAsync("NAME: " + conversion);
                    //conversion = jObject["language"].ToString();
                    //await context.PostAsync(conversion);
                }
            }
        }




        private async Task GetNameData(IDialogContext context, LuisResult result)

        {

            using (var client = new WebClient()) //WebClient 
            {

                EntityRecommendation showEntityRecommendation;

                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                if (result.TryFindEntity(EntityShowdate, out showEntityRecommendation))
                {
                 
                    var json = client.DownloadString("http://api.tvmaze.com/shows/1/episodesbydate?date=");
                    //await context.PostAsync(json);
                    JObject jObject = JObject.Parse(json);

                    string conversion = "";
                    conversion = jObject["name"].ToString();
                    await context.PostAsync("NAME: " + conversion);
                    //await context.PostAsync("plz");
                    //await context.PostAsync(trainEntityRecommendation.Entity);
                    //await context.PostAsync("hello");
                    //var json = client.DownloadString("http://api.tvmaze.com/shows/1/episodesbydate?date=" + trainEntityRecommendation.Entity);
                    //Rootobject tmp = JsonConvert.DeserializeObject<Rootobject>(json);
                    //Class1[] tmp1 = tmp.Property1;
                    //foreach (Class1 nnn in tmp1)
                    //{
                    //    await context.PostAsync(nnn.url);
                    //    await context.PostAsync(nnn.airtime);
                    //    await context.PostAsync(nnn.name);
                    //}
                }

            }
        }



        private async Task GetScheduleData(IDialogContext context, LuisResult result)

        {

            using (var client = new WebClient()) //WebClient  
            {

                EntityRecommendation showEntityRecommendation;
                
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");

                if (result.TryFindEntity(Entityshowname, out showEntityRecommendation))
                {
                    var json = client.DownloadString("http://api.tvmaze.com/singlesearch/shows?q=" + showEntityRecommendation.Entity);
                    JObject jObject = JObject.Parse(json);
                    string conversion = "";
                    conversion = jObject["schedule"]["time"].ToString();
                    await context.PostAsync("TIME: " +conversion);
                    string conversion1 = "";
                    conversion1 = jObject["schedule"]["days"].ToString();
                    await context.PostAsync("DAYS: " +conversion1);

                    //conversion = jObject["url"].ToString();
                    //await context.PostAsync(conversion);


                }
            }
        }


        private async Task GetInfoData(IDialogContext context, LuisResult result)

        {

            using (var client = new WebClient()) //WebClient  
            {

                EntityRecommendation showEntityRecommendation;

                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");

                if (result.TryFindEntity(Entityshowname, out showEntityRecommendation))
                {
                    var json = client.DownloadString("http://api.tvmaze.com/singlesearch/shows?q=" + showEntityRecommendation.Entity);
                    JObject jObject = JObject.Parse(json);
                    List<string> list = new List<string>();
                    string conversion = "";
                    conversion = jObject["id"].ToString();
                    list.Add("id: " + conversion + "\n");
                    conversion = jObject["url"].ToString();
                    list.Add("url: " + conversion + "\n");
                    conversion = jObject["language"].ToString();
                    list.Add("language: " + conversion + "\n");
                    conversion = jObject["type"].ToString();
                    list.Add("type: " + conversion + "\n");
                    conversion = jObject["schedule"]["time"].ToString();
                    list.Add("time: " + conversion + "\n");
                    conversion = jObject["schedule"]["days"].ToString();
                    list.Add("days: " + conversion + "\n");
                    //conversion = jObject["externals"]["tvrage"].ToString();
                    //list.Add("externals\ntvrage: " + conversion + "\n");
                    //conversion = jObject["externals"]["Thetvdb"].ToString();
                    //list.Add("tvrage: " + conversion + "\n");
                    //conversion = jObject["externals"]["imdb"].ToString();
                    //list.Add("imdb: " + conversion + "\n");

                    await context.PostAsync(string.Join("\n",list));

                    // conversion = jObject["schedule"]["days"].ToString();
                    // await context.PostAsync("DAYS: " + conversion);

                    //conversion = jObject["url"].ToString();
                    //await context.PostAsync(conversion);


                }
            }
        }







        private async Task GetRatingData(IDialogContext context, LuisResult result)

        {

            using (var client = new WebClient()) //WebClient  
            {

                EntityRecommendation showEntityRecommendation;

                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");

                if (result.TryFindEntity(Entityshowname, out showEntityRecommendation))
                {
                    var json = client.DownloadString("http://api.tvmaze.com/singlesearch/shows?q=" + showEntityRecommendation.Entity);
                    JObject jObject = JObject.Parse(json);
                    string conversion = "";
                    conversion = jObject["rating"]["average"].ToString();
                    await context.PostAsync("AVERAGE: "+conversion);
                    string conversion1 = "";
                    conversion1 = jObject["weight"].ToString();
                    await context.PostAsync("WEIGHT: "+conversion1);

                    //conversion = jObject["url"].ToString();
                    //await context.PostAsync(conversion);


                }
            }
        }



        private async Task ResumeAfterHotelsFormDialog(IDialogContext context, IAwaitable<HotelsQuery> result)
        { 
            try
            {
                var searchQuery = await result;

                var hotels = await this.GetHotelsAsync(searchQuery);

                await context.PostAsync($"I found {hotels.Count()} hotels:");

                var resultMessage = context.MakeMessage();
                resultMessage.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                resultMessage.Attachments = new List<Attachment>();

                foreach (var hotel in hotels)
                {
                    HeroCard heroCard = new HeroCard()
                    {
                        Title = hotel.Name,
                        Subtitle = $"{hotel.Rating} starts. {hotel.NumberOfReviews} reviews. From ${hotel.PriceStarting} per night.",
                        Images = new List<CardImage>()
                        {
                            new CardImage() { Url = hotel.Image }
                        },
                        Buttons = new List<CardAction>()
                        {
                            new CardAction()
                            {
                                Title = "More details",
                                Type = ActionTypes.OpenUrl,
                                Value = $"https://www.bing.com/search?q=hotels+in+" + HttpUtility.UrlEncode(hotel.Location)
                            }
                        }
                    };

                    resultMessage.Attachments.Add(heroCard.ToAttachment());
                }

                await context.PostAsync(resultMessage);
            }
            catch (FormCanceledException ex)
            {
                string reply;

                if (ex.InnerException == null)
                {
                    reply = "You have canceled the operation.";
                }
                else
                {
                    reply = $"Oops! Something went wrong :( Technical Details: {ex.InnerException.Message}";
                }

                await context.PostAsync(reply);
            }
            finally
            {
                context.Done<object>(null);
            }
        }

        private async Task<IEnumerable<Hotel>> GetHotelsAsync(HotelsQuery searchQuery)
        {
            var hotels = new List<Hotel>();

            // Filling the hotels results manually just for demo purposes
            for (int i = 1; i <= 5; i++)
            {
                var random = new Random(i);
                Hotel hotel = new Hotel()
                {
                    Name = $"{searchQuery.Destination ?? searchQuery.AirportCode} Hotel {i}",
                    Location = searchQuery.Destination ?? searchQuery.AirportCode,
                    Rating = random.Next(1, 5),
                    NumberOfReviews = random.Next(0, 5000),
                    PriceStarting = random.Next(80, 450),
                    Image = $"https://placeholdit.imgix.net/~text?txtsize=35&txt=Hotel+{i}&w=500&h=260"
                };

                hotels.Add(hotel);
            }

            hotels.Sort((h1, h2) => h1.PriceStarting.CompareTo(h2.PriceStarting));

            return hotels;
        }
    }
}

