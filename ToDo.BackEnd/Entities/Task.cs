using System;

namespace ToDo.BackEnd.Entities;

public class Task
{
  public int Id { get; set; }
  public required string Title { get; set; }
  public string Description { get; set; } = "";
  public bool Complete { get; set; } = false;
  public required string Priority { get; set; }
  public required int PriorityId { get; set; }
  public DateTime CreatedAt { get; } = DateTime.Now;  
  public DateTime? CompletedAt { get; set; }
}
