using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace ExamModul3
{
    internal class Program
    {
        static string botToken = "";
        //Bobobekov Shohruz
        static void Main(string[] args)
        {
            #region Tasks
            //Tasks tasks = new Tasks();
            //tasks.Task3(new int[] {4, 3, 9, 1, 2,  3 },7);
            //tasks.Task1(-1);
            //tasks.Task2("123008", "932");
            #endregion

            var botClient = new TelegramBotClient(botToken);
            using var cts = new CancellationTokenSource();

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };

            botClient.StartReceiving(
             updateHandler: UpdateHandlerAsync,
                 pollingErrorHandler: HandlePollingErrorAsync,
                 receiverOptions: receiverOptions,
                 cancellationToken: cts.Token

             );
            Console.WriteLine("\n     Start...\n");
            Console.ReadLine();
            cts.Cancel();
        }
        public static async Task UpdateHandlerAsync(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken)
        {

            ReplyKeyboardMarkup markup = new(new[]
            {
                KeyboardButton.WithRequestLocation("Share Location"),
                KeyboardButton.WithRequestContact("Share Contact"),
            });
            Console.WriteLine(update.Message.Chat.Id);
            await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: "Exam",
                replyMarkup: markup
                );
        }

        #region Error handling
        static Task HandlePollingErrorAsync(
            ITelegramBotClient botClient,
            Exception exception,
            CancellationToken cancellationToken)
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