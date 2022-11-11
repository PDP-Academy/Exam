
using ExamProject.Model;
using System.Text.Json;

namespace ExamProject.Api.ApiBroker;

public class ApiBroker : IApiBroker
{
    const string URL = "https://api.spoonacular.com/food/search?apiKey=";
    const string API_KEY = "6f6862e20b8a457e985415a73cdf3d96";
    HttpClient client = new HttpClient();
    
    public async Task<string> GetDataFromApi()
    {
        var data = await client.GetStringAsync(URL+API_KEY);
        return data;   
    }

    public async Task<Foods> SerializeData()
    {
        var content = GetDataFromApi().Result;
        return JsonSerializer.Deserialize<Foods>(content);
    }
}
