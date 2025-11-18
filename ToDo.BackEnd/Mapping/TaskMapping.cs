using System;
using ToDo.BackEnd.DataTransferObjects;

namespace ToDo.BackEnd.Mapping;

public static class TaskMapping
{
  public static Entities.Task ToEntity(this CreateTaskDTO task)
  {
    return new Entities.Task()
      {
        Title = task.Title,
        Description = task.Description,
        Priority = "",
        PriorityId = task.PriorityId,
        Complete = task.Complete,
        CompletedAt = task.CompletedAt
      };
  }

  public static TaskDTO ToDTO(this Entities.Task task)
  {
    return new TaskDTO(
      task.Id,
      task.Title,
      task.Description,
      task.PriorityId,
      task.Complete,
      task.CreatedAt,
      task.CompletedAt
      );
  }
}
