using System.Reflection.Metadata.Ecma335;
using Telegram.Bot.Types;
using YTGrab.Help;

namespace YTGrab.Interfaces
{
    public interface ICommandListener
    {
        Task GetUpdate(Update update);
        public CommandExecutor Executor { get; }
    }
}
