using App.Metrics;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Types;
using VideoLibrary;
using YTGrab.Help;
using YTGrab.Interfaces;
using YTGrab.Metrics;
using YTGrab.Utils;

namespace YTGrab.Commands
{
    public class AudioCommand : ITelegramCommand, ICommandListener
    {
        public TelegramBotClient Client => Bot.GetTelegramBot();

        public string Name => "/extract";

        public CommandExecutor Executor { get; set; }

        private readonly IMetrics _metrics;

        public AudioCommand(CommandExecutor executor)
        {
            Executor = executor;
        }   

        public async Task Execute(Update update)
        {
            Executor.StartListen(this);
            var chatId = update.Message.Chat.Id;
            string message = "🎥 Please send me the link to the YouTube video you want to extract audio from. Just paste it here!";
            await Client.SendTextMessageAsync(chatId, message);
            Bot.metrics.Measure.Counter.Increment(TgBotMetrics.RequestAudioCounter);
        }

        public async Task GetUpdate(Update update)
        {
            var url = update.Message.Text;
            var chatId = update.Message.Chat.Id;

            try
            {
                Executor.StopListen();
                VideoDownloader videoDownloader = new VideoDownloader();
                AudioExtractor audioExtractor = new AudioExtractor();   

                var videoStream = await videoDownloader.Download(url);
                var audioStream = await audioExtractor.ExtractAudio(videoStream);

                InputFileStream inputFileStream = new InputFileStream(audioStream);
                await Client.SendAudioAsync(chatId, inputFileStream, null, null, null, null, null, "YTGrab", videoDownloader.videoTitle);

                videoStream.Dispose();
                audioStream.Dispose();
                inputFileStream = null;
            }
            catch (Exception ex) 
            {
                string audioDownloadError = $"⚠️ Apologies, there was an error while attempting to extract the audio from this video {url}. Please ensure that the provided YouTube link is correct and try again.";
                await Client.SendTextMessageAsync(chatId, audioDownloadError);
            }
            finally
            {
                GC.Collect();   
            }
        }
    }
}
