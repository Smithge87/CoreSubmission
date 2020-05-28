using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Nancy.Json;
using Newtonsoft.Json.Linq;

namespace Core2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        string[] storyIdList;
        List<Story> storyList = new List<Story>();
        private readonly string fullUrl = "https://hacker-news.firebaseio.com/v0/";
        Story defaultStory = new Story { Title = "Unable to fetch stories. Please consult your admin" };

        public StoryController() {}

        public async Task<IActionResult> Get()
        {
            //-- I get that this is kind of a nested mess, but I did spend a lot of time thinking about it.
            //-- It would be two seperate functions (AT LEAST) but for my uneasyness of the async requirement and the effects on the call from angular.. 
            //-- It seemed like using an async function to call two+ other functions was worse form than 1 larger block.

            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(fullUrl + "newstories.json");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                this.storyIdList = responseBody.Replace("[", "").Replace("]", "").Split(',');

                for (int i = 0; i < 50; i++)
                {
                    HttpResponseMessage response2 = await client.GetAsync(fullUrl + "item/" + storyIdList[i] + ".json");
                    if (response2.IsSuccessStatusCode)
                    {
                        string toList = await response2.Content.ReadAsStringAsync();
                        Story story = Newtonsoft.Json.JsonConvert.DeserializeObject<Story>(toList);
                        storyList.Add(story);
                    }
                }
                return Ok(storyList);
            }
            storyList.Add(defaultStory);
            return Ok(storyList);
        }
    }
}
