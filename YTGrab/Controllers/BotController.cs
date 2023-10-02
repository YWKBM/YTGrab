using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace YTGrab.Controllers
{
    [ApiController]
    [Route("/")]
    public class BotController
    {
        private TelegramBotClient bot = Bot.GetTelegramBot();

        [HttpPost]
        public async void Post(Update update)
        {
            if (update.Message == null)
                return;
            await Bot.updateDistributor.GetUpdate(update);
        }

        [HttpGet]
        public string Get()
        {
            return "Telegram bot was started";
        }
    }
}
