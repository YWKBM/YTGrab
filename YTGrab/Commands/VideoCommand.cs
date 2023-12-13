using App.Metrics;
using System.IO;
using System.Runtime;
using Telegram.Bot;
using Telegram.Bot.Types;
using YTGrab.Help;
using YTGrab.Interfaces;
using YTGrab.Metrics;
using YTGrab.Utils;

namespace YTGrab.Commands
{
    public class VideoCommand : ITelegramCommand, ICommandListener
    {
        public TelegramBotClient Client => Bot.GetTelegramBot();

        public string Name => "/download";

        public CommandExecutor Executor { get; set; }

        private readonly IMetrics _metrics;

        public VideoCommand(CommandExecutor executor)
        {
            Executor = executor;
        }   

        public async Task Execute(Update update)
        {
            Executor.StartListen(this);

            var chatId = update.Message.Chat.Id;
            string message = "🎥 Please send me the link to the YouTube video you want to download. Just paste it here!";

            await Client.SendTextMessageAsync(chatId, message);
            Bot.metrics.Measure.Counter.Increment(TgBotMetrics.RequestVideoCounter);
        }

        public async Task GetUpdate(Update update)
        {
            Executor.StopListen();
            var chatId = update.Message.Chat.Id;
            string url = update.Message.Text;
            try
            {
                VideoDownloader videoDownloader = new VideoDownloader();
                var memoryStream = await videoDownloader.Download(url);
                InputFileStream fileStream = new InputFileStream(memoryStream);
                await Client.SendVideoAsync(chatId, fileStream);
                memoryStream.Dispose();
            }
            catch(Exception ex) 
            {
                string videoDownloadError = $"⚠️ Sorry, there was an error while trying to download this video {url}. Please make sure the provided YouTube link is valid and try again.";
                await Client.SendTextMessageAsync(chatId, videoDownloadError);
            }
            finally
            {
                //TODO: реализовать другую очистку памяти
                GC.Collect();
            }
        }
    }
}
