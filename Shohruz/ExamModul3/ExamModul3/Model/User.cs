using Telegram.Bot.Types;

namespace ExamModul3.Model
{
    internal class User
    {
        public User(int chatId, string name, string phone, Location location, Result book)
        {
            this.chatId = chatId;
            Name = name;
            Phone = phone;
            Location = location;
            Book = book;
        }

        public int chatId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Location Location { get; set; }
        public Result Book { get; set; }
        public override string ToString()
        {
            return $"\n{chatId}" +
                $"\n{Name}" +
                $"\n{Phone}" +
                $"\n{Location.Longitude}" +
                $"\n{Location.Latitude}" +
                $"\n{Book.Name}" +
                $"\n{Book.Image}";
        }
    }
}
