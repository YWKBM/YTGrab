using VideoLibrary;

namespace YTGrab.Utils
{
    public class VideoDownloader
    {
        public async Task<MemoryStream> Download(string url)
        {
            MemoryStream videoStream;

            using (var cli = Client.For(new YouTube()))
            {
                var video = cli.GetVideo(url);
                var videoBytes = await video.GetBytesAsync();
                videoStream = new MemoryStream(videoBytes);
            }

            return videoStream;
        }
    }
}
