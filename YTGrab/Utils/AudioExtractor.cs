using MediaFileProcessor.Models.Common;
using MediaFileProcessor.Processors;

namespace YTGrab.Utils
{
    public class AudioExtractor
    {
        private string ffmpegPath = Bot.Configuration.GetValue<string>("FFmpeg:ffmpegPath");
        private string ffprobePath = Bot.Configuration.GetValue<string>("FFmpeg:ffprobePath");

        public async Task<MemoryStream> ExtractAudio(MemoryStream videoStream)
        {
            VideoFileProcessor videoFileProcessor = new VideoFileProcessor(ffmpegPath, ffprobePath);
            MediaFile mediaFile = new MediaFile(videoStream);
            var memoryStream = await videoFileProcessor.GetAudioFromVideoAsStreamAsync(mediaFile, MediaFileProcessor.Models.Enums.FileFormatType.MP3);
            return memoryStream;    
        }
    }
}
