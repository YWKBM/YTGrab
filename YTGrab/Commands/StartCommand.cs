using Telegram.Bot;
using Telegram.Bot.Types;
using YTGrab.Interfaces;

namespace YTGrab.Commands
{
    public class StartCommand : ITelegramCommand
    {
        public TelegramBotClient Client => Bot.GetTelegramBot();

        public string Name => "/start";

        public async Task Execute(Update update)
        {
            var startDescription = @"
👋 Greetings! I'm here to assist you with downloading and extracting content from YouTube.

With the `/download` command, you can save videos to your device, and using `/extract`, you can obtain audio for enjoyable listening.

Just send me the relevant link, and I'll be delighted to help you fully enjoy the content! 🎥🎶
";
            var chatId = update.Message.Chat.Id;
            await Client.SendTextMessageAsync(chatId, startDescription);
        }
    }
}
