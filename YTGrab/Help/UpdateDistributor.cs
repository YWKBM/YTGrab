using Telegram.Bot.Types;
using YTGrab.Interfaces;

namespace YTGrab.Help
{
    public class UpdateDistributor<T> where T : ITelegramUpdateListener, new()
    {
        Dictionary<long, T> listeners;

        public UpdateDistributor()
        {
            listeners = new Dictionary<long, T>();
        }

        public async Task GetUpdate(Update update)
        {
            if (update.Message != null)
            {

                T? listener = listeners.GetValueOrDefault(update.Message.Chat.Id);

                if (listener is null)
                {
                    listener = new T();
                    listeners.Add(update.Message.Chat.Id, listener);
                    await listener.GetUpdate(update);
                    return;
                }

                await listener.GetUpdate(update);
            }
        }


    }
}
