using App.Metrics;
using Telegram.Bot.Types;
using YTGrab.Commands;
using YTGrab.Interfaces;
using YTGrab.Metrics;

namespace YTGrab.Help
{
    public class CommandExecutor : ITelegramUpdateListener
    {

        private List<ITelegramCommand> commands;
        private ICommandListener commandListener;

        public CommandExecutor()
        {
            commands = new List<ITelegramCommand>
            {
                new StartCommand(),
                new VideoCommand(this),
                new AudioCommand(this),
            };
        }


        public async Task GetUpdate(Update update)
        {
            if (commandListener == null)
            {
                await ExecuteCommand(update);
            }
            else
            {
                await commandListener.GetUpdate(update);
            }
        }

        private async Task ExecuteCommand(Update update) 
        {
            Message msg = update.Message;
            foreach (var command in commands) 
            {
                if (command.Name == msg.Text)
                {
                    await command.Execute(update);
                }
            }
        }

        public void StartListen(ICommandListener newListener)
        {
            commandListener = newListener;  
        }

        public void StopListen()
        {
            commandListener = null;
        }
    }
}
