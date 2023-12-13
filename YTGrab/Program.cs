
using App.Metrics.Formatters.Prometheus;
using Telegram.Bot.Types;
using YTGrab;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Host
    .UseMetricsWebTracking(options =>
    {
        options.OAuth2TrackingEnabled = true;
    })
    .UseMetricsEndpoints(options =>
{
    options.EnvironmentInfoEndpointEnabled = false;
    options.MetricsTextEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
    options.MetricsEndpointOutputFormatter = new MetricsPrometheusProtobufOutputFormatter();
});

var app  = builder.Build();

Bot.Configuration = app.Services.GetRequiredService<IConfiguration>();
Bot.Start();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
