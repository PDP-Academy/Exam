using Imtihon3.Core.Services;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

var botClient = new TelegramBotClient("5441611799:AAHWSNo0Ff-qbS1s1s6zbgg356ZMAy4Ux78");

using var cts = new CancellationTokenSource();

var receiverOptions = new ReceiverOptions
{
    AllowedUpdates = Array.Empty<UpdateType>()
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

cts.Cancel();

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    var message = update.Message;
    if (message is null)
        return;

    if (message.Text is null)
        return;

    var chatId = message.Chat.Id;

    Console.WriteLine($"Received a  message in chat {chatId}.");

    ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
    {
        new KeyboardButton[] { "Ishga tushirish" },
    })
    {
        ResizeKeyboard = true
    };

    if (message.Text == "Ishga tushirish")
    {
    await botClient.SendTextMessageAsync(
        chatId: chatId,
        text: "Assalomu alaykum botga xush kelibsiz.\nOvqat nomini kiriting:",
        replyMarkup: replyKeyboardMarkup,
        cancellationToken: cancellationToken);

    }

    if (message.Type == MessageType.Text)
    {
        IServers servers = new Server();

        var ListOfResult = servers.ConvertObjectToJson(message.Text);

        List<string> list = new List<string>();

       
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
