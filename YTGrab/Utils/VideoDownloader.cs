using VideoLibrary;

namespace YTGrab.Utils
{
    public class VideoDownloader
    {
        public string videoTitle { get; private set; } = string.Empty;
        public async Task<MemoryStream> Download(string url)
        {
            MemoryStream videoStream;

            using (var cli = Client.For(new YouTube()))
            {
                var video = cli.GetVideo(url);

                videoTitle = video.Title;
                
                var videoBytes = await video.GetBytesAsync();
                videoStream = new MemoryStream(videoBytes);
            }

            return videoStream;
        }
    }
}
