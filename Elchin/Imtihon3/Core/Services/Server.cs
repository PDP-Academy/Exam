
using Imtihon3.Core.Brokers.API;
using Imtihon3.Core.Models;
using System.Text.Json;

namespace Imtihon3.Core.Services
{
    public class Server : IServers
    {
        public List<Root.SearchResult> ConvertObjectToJson(string foodName)
        {
            IFoodApi foodApi = new FoodApi();

            var info = foodApi.InitializeAllInfo(foodName).Result;

            var serializeoption = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            var root = JsonSerializer.Deserialize<Root>(info, serializeoption);
            var res = root.searchResults.ToList();
            return res;
        }
    }
}
