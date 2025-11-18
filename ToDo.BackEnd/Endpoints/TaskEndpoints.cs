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
    group.MapGet("/", (TaskStoreContext dbContext) => 
    {
      List<TaskDetailsDTO> taskDTOs = new List<TaskDetailsDTO>();
      dbContext.Tasks.ForEachAsync((task) => taskDTOs.Add(task.ToDetailsDTO()));
      return taskDTOs;  
    });

    // GET /tasks/{id}
    group.MapGet("/{id}", (int id, TaskStoreContext dbContext) =>
    {
      Entities.Task? task = dbContext.Tasks.Find(id);
      return task is null ? Results.NotFound() : Results.Ok(task.ToDetailsDTO());
    }).WithName(GetTaskEndpointName);


    //POST /tasks/new
    group.MapPost("/new", (CreateTaskDTO newTask, TaskStoreContext dbContext) =>
    {
      var Priority = dbContext.Priorities.Find(newTask.PriorityId);
      
      if (Priority is null)
      {
        return Results.UnprocessableEntity();
      }

      Entities.Task task = newTask.ToEntity();
      task.Priority = Priority.Value;

      dbContext.Tasks.Add(task);
      dbContext.SaveChanges();

      return Results.CreatedAtRoute(GetTaskEndpointName, new { id = task.Id }, task.ToSummaryDTO());
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
      return Results.AcceptedAtRoute(GetTaskEndpointName, new { id }, task.ToSummaryDTO());
    });

    //DELETE /tasks/{id}
    group.MapDelete("/{id}", (int id, TaskStoreContext dbContext) =>
    {
      dbContext.Tasks.Where((task) => task.Id == id).ExecuteDelete();
      return Results.NoContent();
    });
    return group;
  }
}
