var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/bye", () => "Bye World!");

app.Run();
