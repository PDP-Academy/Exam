using ExamModul3.ServiceMyBot;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace ExamModul3.Views
{
    public class Mainview
    {
        TelegramBotClient botClient;
        Update update;
        MyBotServise servise;

        public Mainview(TelegramBotClient botClient, Update update)
        {
            this.botClient = botClient;
            this.update = update;
            servise =new MyBotServise();
        }

        public async void Start()
        {


            if (!servise.CheckUser(update.Message.Chat.Id))
            {
                ReplyKeyboardMarkup markup = new(new[]
                {
                KeyboardButton.WithRequestLocation("Share Location"),
                KeyboardButton.WithRequestContact("Share Contact"),
                });

               await botClient.SendTextMessageAsync(
                   chatId: update.Message.Chat.Id,
                   text: "Exam",
                   replyMarkup: markup
                   );
            }
            else
            {               
                var foods=await servise.GetFoods();
                var markup = GenerateButtons(foods.count);
                await botClient.SendTextMessageAsync(
                      chatId: update.Message.Chat.Id,
                      text: "Hello",
                      replyMarkup: markup
                      );               
            }
        }
        public static InlineKeyboardMarkup GenerateButtons(int count)
        {
            int maxButtonsLength = 5;
            var buttons = new List<List<InlineKeyboardButton>>();

            for (int index = 0; index < count; index++)
            {
                if (index % maxButtonsLength == 0)
                    buttons.Add(new List<InlineKeyboardButton>());

                buttons[index / maxButtonsLength].Add(
                    new InlineKeyboardButton((index+1).ToString())
                    {
                        CallbackData = $"food {index}"
                    }
                );
            }

            return new InlineKeyboardMarkup(buttons);
        }
    }
}
