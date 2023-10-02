using Telegram.Bot.Types;

namespace YTGrab.Interfaces
{
    public interface ITelegramUpdateListener
    {
        Task GetUpdate(Update update);
    }
}
