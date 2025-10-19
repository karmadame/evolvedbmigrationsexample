using TodoMicroService;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
var app = builder.Build();
builder.Services.ConfigureEvolveMigration(builder.Configuration);

app.MapDefaultEndpoints();

app.MapGet("/", () => "Hello World!");

app.Run();