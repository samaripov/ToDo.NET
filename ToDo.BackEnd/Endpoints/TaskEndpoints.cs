using System;
using ToDo.BackEnd.Data;
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
      1,
      false,
      DateTime.Now,
      DateTime.Now
    ),
    new (
      2,
      "HW",
      "Finish homework",
      1,
      false,
      DateTime.Now,
      DateTime.Now
    ),
    new (
      3,
      "Bathroom",
      "Wash the bathroom",
      1,
      false,
      DateTime.Now,
      DateTime.Now
    ),
  ];

  public static RouteGroupBuilder MapTasksEndpoints(this WebApplication app)
  { 
    var group = app.MapGroup("tasks").WithParameterValidation();
    // GET /tasks
    group.MapGet("/", (TaskStoreContext dbContext) => dbContext.Tasks);

    // GET /tasks/{id}
    group.MapGet("/{id}", (int id, TaskStoreContext dbContext) =>
    {
      var task = dbContext.Tasks.Find(id);
      return task is null ? Results.NotFound() : Results.Ok(task);
    }).WithName(GetTaskEndpointName);


    //POST /tasks/new
    group.MapPost("/new", (CreateTaskDTO newTask, TaskStoreContext dbContext) =>
    {
      var Priority = dbContext.Priorities.Find(newTask.PriorityId);
      
      if (Priority is null)
      {
        return Results.UnprocessableEntity();
      }

      Entities.Task task = new()
      {
        Title = newTask.Title,
        Description = newTask.Description,
        Priority = Priority.Value,
        PriorityId = newTask.PriorityId,
        Complete = newTask.Complete,
        CompletedAt = newTask.CompletedAt
      };

      dbContext.Tasks.Add(task);
      dbContext.SaveChanges();

      return Results.CreatedAtRoute(GetTaskEndpointName, new { id = task.Id }, task);
    });

    //PUT /tasks/{id}/edit/
    group.MapPut("/{id}/edit", (int id, UpdateTaskDTO updatedTask, TaskStoreContext dbContext) =>
    {
      var task = dbContext.Tasks.Find(id);

      if (task is null)
      {
        return Results.NotFound();
      }

      var priority = dbContext.Priorities.Find(updatedTask.PriorityId);
      if (priority is null)
      {
        return Results.UnprocessableEntity();
      }
    
      task.Title = updatedTask.Title;
      task.Description = updatedTask.Description;
      task.PriorityId = updatedTask.PriorityId;
      task.Priority = priority.Value;
      task.Complete = updatedTask.Complete;
      task.CompletedAt = updatedTask.CompletedAt;

      dbContext.SaveChanges();
      return Results.AcceptedAtRoute(GetTaskEndpointName, new { id }, task);
    });

    //DELETE /tasks/{id}
    group.MapDelete("/{id}", (int id, TaskStoreContext dbContext) =>
    {
      var task = dbContext.Tasks.Find(id);
      if (task is null)
      {
        return Results.NotFound();
      }
      dbContext.Tasks.Remove(task);
      dbContext.SaveChanges();
      return Results.Accepted();
    });
    return group;
  }
}
