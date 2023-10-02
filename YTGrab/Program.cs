
using Telegram.Bot.Types;
using YTGrab;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson();

var app  = builder.Build();

Bot.Configuration = app.Services.GetRequiredService<IConfiguration>();
Bot.Start();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
