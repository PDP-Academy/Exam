
using ExamProject.Api.ApiBroker;
using ExamProject.Service;
using Telegram.Bot.Types.ReplyMarkups;

namespace ExamProject.Extensions;

public static class Extencions
{


    public static InlineKeyboardMarkup Button()
    {
        IApiBroker apiBroker = new ApiBroker();
        IServiceFood food = new ServiceFood(apiBroker);
        var data = food.GetFoods();
        var buttons = new List<InlineKeyboardButton>()
        {
            new InlineKeyboardButton(data[0].Name)
            {
                CallbackData = "0"
            },
            new InlineKeyboardButton(data[1].Name)
            {
                CallbackData = "1"
            },
            new InlineKeyboardButton(data[2].Name)
            {
                CallbackData = "2"
            },
            new InlineKeyboardButton(data[3].Name)
            {
                CallbackData = "3"
            },
            new InlineKeyboardButton(data[4].Name)
            {
                CallbackData = "4"
            },
            new InlineKeyboardButton(data[5].Name)
            {
                CallbackData = "5"
            }
        };

        return new InlineKeyboardMarkup(buttons);
    }
}
