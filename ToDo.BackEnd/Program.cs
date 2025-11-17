using ToDo.BackEnd;
using ToDo.BackEnd.DataTransferObjects;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

const string GetTaskEndpointName = "GetTask";

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

// GET /tasks/{id}
app.MapGet("tasks/{id}", (int id) => tasks.Find((task) => task.Id == id)).WithName(GetTaskEndpointName);


//POST /tasks/new
app.MapPost("tasks/new", (CreateTaskDTO newTask) =>
{
  TaskDTO task = new(
    tasks.Count + 1,
    newTask.Title,
    newTask.Description,
    newTask.Complete,
    newTask.CreatedAt,
    newTask.CompletedAt
  );

  tasks.Add(task);

  return Results.CreatedAtRoute(GetTaskEndpointName, new { id = task.Id }, task);
});

//PATCH /tasks/{id}/edit/
app.MapPut("tasks/{id}/edit", (int id, UpdateTaskDTO updatedTask) =>
{ 
  var taskIndex = tasks.FindIndex((task) => task.Id == id);

  if (taskIndex == -1)
  {
    return Results.NotFound();
  }

  tasks[taskIndex] = new TaskDTO (
    id,
    updatedTask.Title,
    updatedTask.Description,
    updatedTask.Complete,
    updatedTask.CreatedAt,
    updatedTask.CompletedAt
  );
  return Results.AcceptedAtRoute(GetTaskEndpointName, new { id }, tasks[taskIndex]);
});

//DELETE /tasks/{id}
app.MapDelete("tasks/{id}", (int id) =>
{
  tasks.RemoveAll(task => task.Id == id);

  return Results.Accepted();
});

app.Run();
