using ExamModul3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExamModul3.Broker
{
    public class FoodApiBroker
    {
        private string url = "https://api.spoonacular.com/food/search?apiKey=3137aa3868324bf7b32dca8f7e551799";
        public async Task<List<Result>> GetResult()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            var root = JsonSerializer.Deserialize<Root>(json);
            return root.SearchResults[0].Results;
        }

    }
}
