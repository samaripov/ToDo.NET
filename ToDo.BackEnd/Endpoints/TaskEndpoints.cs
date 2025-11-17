using System;
using ToDo.BackEnd.DataTransferObjects;

namespace ToDo.BackEnd.Endpoints;

public static class TaskEndpoints
{
  const string GetTaskEndpointName = "GetTask";

  private static readonly List<TaskDTO> tasks = [
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

  public static RouteGroupBuilder MapTasksEndpoints(this WebApplication app)
  { 
    var group = app.MapGroup("tasks");
    // GET /tasks
    group.MapGet("/", () => tasks);

    // GET /tasks/{id}
    group.MapGet("/{id}", (int id) =>
    {
      var task = tasks.Find((task) => task.Id == id);
      return task is null ? Results.NotFound() : Results.Ok(task);
    }).WithName(GetTaskEndpointName);


    //POST /tasks/new
    group.MapPost("/new", (CreateTaskDTO newTask) =>
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
    group.MapPut("/{id}/edit", (int id, UpdateTaskDTO updatedTask) =>
    {
      var taskIndex = tasks.FindIndex((task) => task.Id == id);

      if (taskIndex == -1)
      {
        return Results.NotFound();
      }

      tasks[taskIndex] = new TaskDTO(
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
    group.MapDelete("/{id}", (int id) =>
    {
      var task = tasks.RemoveAll(task => task.Id == id);
      return task == 0 ? Results.NotFound() : Results.Accepted();
    });
    return group;
  }
}
