using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using System.Text.Json;

namespace pdpexam;
class Program
{
    public static Dictionary<long, User> users = new Dictionary<long, User>();
    
    static async Task Main(string[] args)
    {

        Root root = await GetProductsAsync("74864c83ed494d4bb20b8d3c3cbdefc6");
        List<Result> prods = root.searchResults[0].results;
        await TeleBot("5783221716:AAERgmXfTTvCSr7wzlS0GhBV1B5Agw-L6O8", prods);

    }

    static async Task<Root> GetProductsAsync(string apikey)
    {
        HttpClient client = new HttpClient();


        var request = await client.GetAsync($@"https://api.spoonacular.com/food/search?apiKey={apikey}");
       
        var json = await request.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Root>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        
    }

    static async Task TeleBot(string apikey, List<Result> products)
    {
        var botClient = new TelegramBotClient(apikey);

        using var cts = new CancellationTokenSource();

        KeyboardButton getPhone = new KeyboardButton("Telefon raqamni yuborish") { RequestContact = true };
        KeyboardButton getLocation = new KeyboardButton("Manzilni yuborish yuborish") { RequestLocation = true };



        // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
        };
        botClient.StartReceiving(
            updateHandler: HandleUpdateAsync,
            pollingErrorHandler: HandlePollingErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: cts.Token
        );

        var me = await botClient.GetMeAsync();

        Console.WriteLine($"Start listening for @{me.Username}");
        Console.ReadLine();

        // Send cancellation request to stop bot
        cts.Cancel();

        async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Only process Message updates: https://core.telegram.org/bots/api#message
            

            var chatId = update.Message.Chat.Id;

            Console.WriteLine($"Received a '{update.Message.Text}' message in chat {chatId}.");

            // Echo received message text
            if(update.Message.Text == "/start")
            {
                if (!users.ContainsKey(chatId))
                {
                    ReplyKeyboardMarkup markup = new ReplyKeyboardMarkup(getPhone) { ResizeKeyboard = true };
                    users.Add(chatId, new User { UserStatus = Status.number });
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Assalomu aleykom! raqamingizni kiriting",
                        replyMarkup: markup);
                    return;
                }

            }
            if (users.ContainsKey(chatId))
            {
                User user = users[chatId];

                if (user.UserStatus == Status.number)
                {
                    user.Number = update.Message.Contact.PhoneNumber;
                    user.UserStatus = Status.name;
                    
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Ismingizni kiriting",
                        replyMarkup: new ReplyKeyboardRemove());
                    return;
                }
                if(user.UserStatus == Status.name)
                {
                    user.Name = update.Message.Text;
                    user.UserStatus = Status.geocode;
                    ReplyKeyboardMarkup markup = new ReplyKeyboardMarkup(getLocation) {  ResizeKeyboard = true};
                    
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Manzilingizni yuboring",
                        replyMarkup: markup);
                    return;
                }
                if(user.UserStatus == Status.geocode)
                {
                    Console.WriteLine(update.Message.Location.Latitude);
                    Console.WriteLine(update.Message.Location.Longitude);
                    user.GeoCode[0] = update.Message.Location.Latitude;
                    user.GeoCode[1] = update.Message.Location.Longitude;

                    user.UserStatus = Status.registred;

                    

                    InlineKeyboardButton btn(string callback)
                    {
                        return InlineKeyboardButton.WithCallbackData("Buyurtma berish", callback);
                    }
                    
                    for(int i = 0; i < 10; i++)
                    {
                        InlineKeyboardMarkup[] markups = new InlineKeyboardMarkup[] { btn(i.ToString()) };
                        await botClient.SendPhotoAsync(
                        chatId: chatId,
                        photo: products[i].image,
                        caption: products[i].name);
                    }
                }
            }
        }

        Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}
