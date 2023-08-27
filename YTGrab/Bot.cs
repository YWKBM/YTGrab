using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net;
using System.Runtime.CompilerServices;
using Telegram.Bot;
using Telegram.Bot.Types;
using YTGrab.Help;
using YTGrab.Help;

namespace YTGrab
{
    public static class Bot
    {
        public static IConfiguration Configuration { get; set; }

        public static UpdateDistributor<CommandExecutor> updateDistributor = new UpdateDistributor<CommandExecutor>();

        private static string webHookUrl;
        private static string botToken;
        private static TelegramBotClient client;


        private static async void ConfigureWebHook()
        {

            var request = (HttpWebRequest)WebRequest.Create($"https://api.telegram.org/bot{botToken}/setWebhook?url={webHookUrl}");
            request.Method = "POST";
            request.ContentType = "application/json";

            var resposne = (HttpWebResponse)request.GetResponse();

            using (StreamReader reader = new StreamReader(resposne.GetResponseStream()))
            {
               var resposneString = reader.ReadToEnd();
               Console.WriteLine(resposneString);

            };
        }

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
            webHookUrl = Configuration.GetValue<string>("BotConfiguration:webHookURL");
            botToken = Configuration.GetValue<string>("BotConfiguration:botToken");

            client = new TelegramBotClient(botToken);

            ConfigureWebHook();
        }
    }
}
