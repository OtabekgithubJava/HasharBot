using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using UnityBot.Bot.Models.Entities;
using UnityBot.Bot.Services.UserServices;

namespace UnityBot.Bot.Services.Handlers
{
    public partial class BotUpdateHandler : IUpdateHandler
    {
        private readonly ILogger<BotUpdateHandler> _logger;
        private readonly IUserService _userService;

        public BotUpdateHandler(ILogger<BotUpdateHandler> logger, UserServices.IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
               
                var handler = update.Type switch
                {
                    UpdateType.Message => HandleMessageAsync(botClient, update.Message, cancellationToken),
                    UpdateType.CallbackQuery => HandleCallbackQueryAsync(botClient, update.CallbackQuery, cancellationToken),
                    _ => HandleUnknownMessageAsync(botClient, update, cancellationToken)
                };

                try
                {
                    await ClearMessageMethod(botClient, update.Message, cancellationToken);
                    await ClearUpdateMethod(botClient, update.CallbackQuery, cancellationToken);

                    await handler;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Handler or CLear ex in UpdateAsync");
                }
            }
            catch
            {
                Console.WriteLine("UpdateAysncda xatolik");
                return;
            }
        }

        private async Task HandleUnknownMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                Console.WriteLine("Not impelemented mesage");
            }
            catch
            {
                Console.WriteLine("HandleUnknownMessageAsync error");
            }
        }
    }
}