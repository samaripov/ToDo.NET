using ToDo.BackEnd;
using ToDo.BackEnd.Data;
using ToDo.BackEnd.Endpoints;

SQLitePCL.Batteries.Init();

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("TaskStore");
builder.Services.AddSqlite<TaskStoreContext>(connectionString);

var app = builder.Build();

app.MapTasksEndpoints();
app.MapPrioritiesEndpoints();

await app.MigrateDBAsync();
app.Run();
