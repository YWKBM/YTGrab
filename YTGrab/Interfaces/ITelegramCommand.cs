using Telegram.Bot;
using Telegram.Bot.Types;

namespace YTGrab.Interfaces
{
    public interface ITelegramCommand
    {
        public TelegramBotClient Client { get; }
        public string Name { get; }
        Task Execute(Update update);
    }
}
