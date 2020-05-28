using System;
using System.Net.Http;
using Xunit;

namespace Core2Tests
{
    public class UnitTesting
    {
        [Fact]
        public async void HttpConnectionBulkStories()
        {
            //-- So that I know my connection for call 1 returns 'success'

            string fullUrl = "https://hacker-news.firebaseio.com/v0/";

            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(fullUrl + "newstories.json");

            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async void StoryIdsList()
        {
            //-- So that I know my list of story Ids is clean

            string[] storyIdList = new string[] { };
            string fullUrl = "https://hacker-news.firebaseio.com/v0/";

            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(fullUrl + "newstories.json");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                storyIdList = responseBody.Replace("[", "").Replace("]", "").Split(',');
            }
            Assert.True(storyIdList.Length == 500);
            Assert.DoesNotContain('[', storyIdList[0]);
            Assert.DoesNotContain(']', storyIdList[499]);

        }

        [Fact]
        public async void HttpConnectionSingleStory()
        {
            //-- So that I know my second call is returning 'success'

            using HttpClient client = new HttpClient();
            string fullUrl = "https://hacker-news.firebaseio.com/v0/";
            string[] storyIdList = new string[] { "9129911", "9129199", "9127761" };
            HttpResponseMessage response2 = await client.GetAsync(fullUrl + "item/" + storyIdList[0] + ".json");

            Assert.True(response2.IsSuccessStatusCode);
        }
    }
}
