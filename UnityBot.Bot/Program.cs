using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Polling;
using UnityBot.Bot.Persistanse;
using UnityBot.Bot.Services;
using UnityBot.Bot.Services.Handlers;
using UnityBot.Bot.Services.UserServices;

namespace UnityBot.Bot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Logging.ClearProviders();
            builder.Services.AddSingleton<IUpdateHandler, BotUpdateHandler>();
            builder.Services.AddSingleton<IUserService, UserService>();
            builder.Services.AddDbContext<UnityDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("Db"));
            });
            builder.Services.AddSingleton(t => new TelegramBotClient(builder.Configuration.GetValue("BotToken", string.Empty)));
            builder.Services.AddHostedService<BotBackgroundService>();

            var app = builder.Build();


            app.Run();
        }
    }
}
