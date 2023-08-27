using Telegram.Bot.Types;
using YTGrab.Commands;
using YTGrab.Interfaces;

namespace YTGrab.Help
{
    public class CommandExecutor : ITelegramUpdateListener
    {

        private List<ITelegramCommand> commands;

        public CommandExecutor()
        {
            commands = new List<ITelegramCommand>
            {
                new StartCommand(),
            };
        }


        public async Task GetUpdate(Update update)
        {
            Message msg = update.Message;
            if (msg.Text == null)
                return;

            foreach (var command in commands) 
            {
                if (command.Name == msg.Text)
                    await command.Execute(update);
            }
        }
    }
}
