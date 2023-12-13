using App.Metrics;
using App.Metrics.Counter;
using App.Metrics.Filters;

namespace YTGrab.Metrics
{
    public static class TgBotMetrics
    {
        public static CounterOptions RequestVideoCounter => new CounterOptions
        {
            Context = "Video",
            Name = "User video request",
            MeasurementUnit = Unit.Calls
        };

        public static CounterOptions RequestAudioCounter => new CounterOptions
        {
            Context = "Audio",
            Name = "User audio request",
            MeasurementUnit = Unit.Calls
        };
    }
}
