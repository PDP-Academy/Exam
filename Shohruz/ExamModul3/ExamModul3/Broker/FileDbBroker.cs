
using ExamModul3.Model;
//using Telegram.Bot.Types;

namespace ExamModul3.Broker
{
    internal class FileDbBroker
    {
        private string path = "UserData.txt";
        public async Task Write(List<User> users)
        {
            File.WriteAllText(path, "");
            foreach (var item in users)
            {
                await File.AppendAllTextAsync(path, "\n==================");
                await File.AppendAllTextAsync(path, item.ToString());
            }
        }
        public async Task<List<User>> Read()
        {
            string[] text=await File.ReadAllLinesAsync(path);
            List<User> users=new List<User>();
            for (int i = 1; i < text.Length; )
            {
                int id = int.Parse(text[i]);
                Telegram.Bot.Types.Location location = new Telegram.Bot.Types.Location();
                location.Longitude  = double.Parse(text[i+3]);
                location.Latitude  = double.Parse(text[i+4]);
                Result book= new Result();
                book.Name= text[i+5];
                book.Image= text[i+6];              
             
                
                users.Add(new User(id, text[i + 1], text[i+2],location,book));
                i += 8;
            }
            return users;
        }
    }
}
