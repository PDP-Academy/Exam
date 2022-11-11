using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BotImtixon.Api;
using BotImtixon.Model;
using Telegram.Bot.Types;

namespace BotImtixon.File
{
    internal class Files
    {
        private BotImtixon.Api.Api api = new BotImtixon.Api.Api();
        public string Deserisalition()
        {
            string Content = api.JsonStringContents();
            var serializationOption = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            var info = JsonSerializer.Deserialize<Root>(Content, serializationOption);
            string s = info.ToString();
            Console.WriteLine(s);
            return s;

        }

        public void FileRead(string Path)
        {

        }

        public void FileWrite(string Content)
        {

        }

        public string Serisalition(string Content)
        {
            return "";
        }
    }
}
