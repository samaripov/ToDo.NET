using ToDo.BackEnd;
using ToDo.BackEnd.DataTransferObjects;
using ToDo.BackEnd.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapTasksEndpoints();

app.Run();
