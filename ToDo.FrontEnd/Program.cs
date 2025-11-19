using ToDo.FrontEnd.Clients;
using ToDo.FrontEnd.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
  .AddInteractiveServerComponents();

var taskStoreURL = builder.Configuration["TaskStoreAPIUrl"] ?? 
  throw new Exception("TaskStoreAPIUrl is not set.");

builder.Services.AddHttpClient<TasksClient>(client =>
{
    client.BaseAddress = new Uri(taskStoreURL); 
});

builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error", createScopeForErrors: true);
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

// app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>()
  .AddInteractiveServerRenderMode();

app.Run();
