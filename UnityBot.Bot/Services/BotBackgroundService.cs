using Telegram.Bot;
using Telegram.Bot.Polling;

namespace UnityBot.Bot.Services
{
    public class BotBackgroundService : BackgroundService
    {
        private readonly ILogger<BotBackgroundService> _logger;
        private readonly TelegramBotClient _client;
        private readonly IUpdateHandler _handler;
        public BotBackgroundService(ILogger<BotBackgroundService> logger, TelegramBotClient client, IUpdateHandler handler)
        {
            _logger = logger;
            _client = client;
            _handler = handler;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                var bot = await _client.GetMeAsync(stoppingToken);

                _logger.LogInformation("Bot starting with this username: @{bot.Username}", bot.Username);

                Console.WriteLine($"Bot starting with this username: @{bot.Username}");

                _client.StartReceiving(
                    _handler.HandleUpdateAsync,
                    _handler.HandlePollingErrorAsync,
                    new ReceiverOptions()
                    {
                        ThrowPendingUpdates = true
                    }, stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred in BotBackgroundService");
                Console.WriteLine($"Ex in Bcg Service: {ex.Message}");
            }
        }
    }
}
