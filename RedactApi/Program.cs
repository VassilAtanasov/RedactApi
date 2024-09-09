using RedactApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Configure the redaction list and port from appsettings.json
var redactionWords = builder.Configuration.GetSection("RedactionWords").Get<string[]>() ?? [];
builder.Services.AddSingleton(new RedactionService(redactionWords));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddFile("Logs/redaction-log-{Date}.txt");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if (string.IsNullOrEmpty(builder.Configuration.GetValue<string>("Port")))
{
    app.Run();
}
else
{
    app.Run($"https://localhost:{builder.Configuration.GetValue<int>("Port")}");
}