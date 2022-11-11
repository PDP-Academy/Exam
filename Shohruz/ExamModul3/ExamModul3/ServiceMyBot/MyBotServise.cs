using ExamModul3.Broker;
using ExamModul3.Model;

namespace ExamModul3.ServiceMyBot
{
    internal class MyBotServise
    {
        private List<User> users;
        private List<Result> apiFoodResult;
        private FoodApiBroker foodBroker;
        private FileDbBroker fileDbBroker;

        public MyBotServise()
        {
            foodBroker = new FoodApiBroker();
            fileDbBroker = new FileDbBroker();
            apiFoodResult= foodBroker.GetResult().Result;
            users = fileDbBroker.Read().Result;
            //Telegram.Bot.Types.Location loc=new Telegram.Bot.Types.Location();
            //User user = new User(1035640073, "Shohruz", "+998901033685", loc, new Result());
        }

        public bool CheckUser(long id)
        {
            foreach (var item in users)
            {
                if(item.chatId==id) return true;
            }
            return false;
        }
        public async Task< (string food,int count)> GetFoods()
        {
           var foods=await foodBroker.GetResult();
            string res = "";
            foreach (var item in foods)
            {
                res += item.Name;
            }
            return (res,foods.Count);
        }

    }
}
