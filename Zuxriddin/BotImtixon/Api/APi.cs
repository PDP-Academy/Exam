using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace BotImtixon.Api;

public class Api
{
    private HttpClient httpClient = new HttpClient();

    private string Url = "https://api.spoonacular.com/food/search?apiKey=b7009e78c10b4c08ba7291582f2fe39a";
    
    private HttpResponseMessage response = new HttpResponseMessage();

    public HttpResponseMessage ResponseMessage()
    {
        response = httpClient.GetAsync(Url).Result;
        return response;
    }
    public string JsonStringContents()
    {
        return ResponseMessage().Content.ReadAsStringAsync().Result;
    }
}
