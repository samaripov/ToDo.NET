using ToDo.BackEnd.DataTransferObjects;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

List<TaskDTO> tasks = [
  new (
    1,
    "Dishes",
    "Wash the dishes",
    false,
    DateTime.Now,
    DateTime.Now
  ),
  new (
    2,
    "HW",
    "Finish homework",
    false,
    DateTime.Now,
    DateTime.Now
  ),
  new (
    3,
    "Bathroom",
    "Wash the bathroom",
    false,
    DateTime.Now,
    DateTime.Now
  ),
];
// GET /tasks
app.MapGet("tasks", () => tasks);

app.Run();
