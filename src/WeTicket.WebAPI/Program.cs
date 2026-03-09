using WeTicket.Infrastructure.DateTimes;
using WeTicket.Infrastructure.Guids;
using WeTicket.Persistence;
using WeTicket.WebAPI.ConfigurationOptions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
AppSettings appSettings = new();
builder.Configuration.Bind(appSettings);

builder.Services.AddControllers();
builder.Services.AddOpenApi(); // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddPersistence(appSettings.ConnectionStrings["Default"]);
builder.Services.AddDateTimeProvider();
builder.Services.AddGuidProvider();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();