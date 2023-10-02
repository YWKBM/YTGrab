using Telegram.Bot.Types;
using YTGrab.Help;

namespace YTGrab.Interfaces
{
    public interface ICommandListener
    {
        public async Task GetUpdate(Update update) { }
        public CommandExecutor Executor { get; }
    }
}
