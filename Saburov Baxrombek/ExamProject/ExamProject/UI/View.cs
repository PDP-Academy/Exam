using ExamProject.Service;
using ExamProject.Model;
using ExamProject.Api.ApiBroker;
using Telegram.Bot;
using ExamProject.Extensions;

namespace ExamProject.UI;

public class View
{
    private List<Data> data;
    private IServiceFood service;
    private IApiBroker apiBroker;
    public View()
    {
        apiBroker = new ApiBroker();
        service = new ServiceFood(apiBroker);
    }
    
    public void StartingView()
    {
        this.data = service.GetFoods();
        PrintData();
    }

    public void PrintData()
    {
        foreach(var item in data)
        {
            Console.WriteLine(item.Name + "  " + item.Image);
        }
    }

    public async Task MessageMenu(ITelegramBotClient botClient, long chatId, int messageId)
    {
        var markup = Extencions.Button();
        await botClient.SendTextMessageAsync(
            chatId: chatId,

            text: "Tanlang :",
            replyMarkup: markup);

    }

}
