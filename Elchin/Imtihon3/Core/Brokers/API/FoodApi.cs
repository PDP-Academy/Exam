using Imtihon3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imtihon3.Core.Brokers.API
{
    public class FoodApi : IFoodApi
    {
        private string url = "https://api.spoonacular.com/food/search?";
        private string myKey = "apiKey=b56bd211a546414eba98274fa59d9eab";


        public async Task<string> InitializeAllInfo(string foodName)
        {
            url = url + $"query={foodName}&";

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(url);

            var info = client.GetAsync(url).Result;

            return await info.Content.ReadAsStringAsync();
        }
    }
}
