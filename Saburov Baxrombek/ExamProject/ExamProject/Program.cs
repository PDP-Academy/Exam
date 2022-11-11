using Telegram.Bot;

using ExamProject.UI;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;

class main
{
    private const string Token = "5663425745:AAEkyxwfao8ZoSzFCbSmez0u2LDlY8dALtI";

    private string curCallBack = "";
    static async Task Main(string[] args)
    {
        
       
        View view = new View();
        var botClient = new TelegramBotClient(Token);

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
        static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        { 
            var Updatehandler = update switch
            {
                { Message: { } } => OnMessageText(),
                { CallbackQuery: { } } => OnCallbackQueryReceived()
            };

            await Updatehandler;



            async Task OnMessageText()
            {
                
                Message message = update.Message;
                var chatId = update.Message.Chat.Id;

                Console.WriteLine($"Received a '{message}' message in chat {message.Chat.Username}.");
               
                if (message.Text == "/start")
                {

                    await view.MessageMenu(botClient, chatId, message.MessageId);
                }
                else
                {
                   
                }
            }

            async Task OnCallbackQueryReceived()
            {
                
                string callback = update.CallbackQuery.Data;
                var chatId = update.CallbackQuery.Message.Chat.Id;
                var message = update.CallbackQuery.Message;

                if (callback == "1")
                {
                    
                    await botClient.DeleteMessageAsync(
                        chatId: chatId,
                        messageId: message.MessageId);

                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Buyurtma qabul qilindi ",
                        cancellationToken: cancellationToken);
                }
                if (callback == "2")
                {
                    
                    await botClient.DeleteMessageAsync(
                        chatId: chatId,
                        messageId: message.MessageId);

                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text:  "Buyurtma qabul qilindi",
                        cancellationToken: cancellationToken);
                }




                }

            }









        }

        


        #region Handle Error
        static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
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
        #endregion


    }
}
