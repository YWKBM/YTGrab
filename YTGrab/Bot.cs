using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net;
using System.Runtime.CompilerServices;
using Telegram.Bot;
using Telegram.Bot.Types;
using YTGrab.Help;

namespace YTGrab
{
    public static class Bot
    {
        public static IConfiguration Configuration { get; set; }

        public static UpdateDistributor<CommandExecutor> updateDistributor = new UpdateDistributor<CommandExecutor>();

        private static string botToken;
        private static TelegramBotClient client;


        public static TelegramBotClient GetTelegramBot()
        {
            if (client != null)
            {
                return client;
            }

            return null;
        }

        public static void Start()
        {
            botToken = Configuration.GetValue<string>("BotConfiguration:botToken");
            client = new TelegramBotClient(botToken);
        }
    }
}
