﻿using Telegram.Bot.Types;
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
            long chatId = update.Message.Chat.Id;
            T? listener = listeners.GetValueOrDefault(chatId);

            if (listener is null)
            {
                listener = new T();
                listeners.Add(chatId, listener);
                await listener.GetUpdate(update);
                return;
            }

            await listener.GetUpdate(update);
        }


    }
}
