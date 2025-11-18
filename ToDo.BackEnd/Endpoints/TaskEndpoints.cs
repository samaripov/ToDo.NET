using System;
using Microsoft.EntityFrameworkCore;
using ToDo.BackEnd.Data;
using ToDo.BackEnd.DataTransferObjects;
using ToDo.BackEnd.Mapping;

namespace ToDo.BackEnd.Endpoints;

public static class TaskEndpoints
{
  const string GetTaskEndpointName = "GetTask";

  public static RouteGroupBuilder MapTasksEndpoints(this WebApplication app)
  { 
    var group = app.MapGroup("tasks").WithParameterValidation();
    // GET /tasks
    group.MapGet("/", async (TaskStoreContext dbContext) => 
      await dbContext.Tasks
        .Select(task => task.ToDetailsDTO())
        .AsNoTracking()
        .ToListAsync()
    );

    // GET /tasks/{id}
    group.MapGet("/{id}", async (int id, TaskStoreContext dbContext) =>
    {
      Entities.Task? task = await dbContext.Tasks.FindAsync(id);
      return task is null ? Results.NotFound() : Results.Ok(task.ToDetailsDTO());
    }).WithName(GetTaskEndpointName);


    //POST /tasks/new
    group.MapPost("/new", async (CreateTaskDTO newTask, TaskStoreContext dbContext) =>
    {
      var Priority = dbContext.Priorities.Find(newTask.PriorityId);
      
      if (Priority is null)
      {
        return Results.UnprocessableEntity();
      }

      Entities.Task task = newTask.ToEntity();
      task.Priority = Priority.Value;

      dbContext.Tasks.Add(task);
      await dbContext.SaveChangesAsync();

      return Results.CreatedAtRoute(GetTaskEndpointName, new { id = task.Id }, task.ToSummaryDTO());
    });

    //PUT /tasks/{id}/edit/
    group.MapPut("/{id}/edit", async (int id, UpdateTaskDTO updatedTask, TaskStoreContext dbContext) =>
    {
      var existingTask = await dbContext.Tasks.FindAsync(id);

      if (existingTask is null)
      {
        return Results.NotFound();
      }

      var priority = await dbContext.Priorities.FindAsync(updatedTask.PriorityId);
      if (priority is null)
      {
        return Results.UnprocessableEntity();
      }
      var updatedTaskEntity = updatedTask.ToEntity(id);
      updatedTaskEntity.Priority = priority.Value;

      dbContext.Entry(existingTask)
        .CurrentValues
        .SetValues(updatedTaskEntity);

      await dbContext.SaveChangesAsync();
      return Results.AcceptedAtRoute(GetTaskEndpointName, new { id }, existingTask.ToSummaryDTO());
    });

    //DELETE /tasks/{id}
    group.MapDelete("/{id}", async (int id, TaskStoreContext dbContext) =>
    {
      await dbContext.Tasks.Where((task) => task.Id == id).ExecuteDeleteAsync();
      return Results.NoContent();
    });
    return group;
  }
}
