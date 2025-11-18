using System;
using ToDo.BackEnd.DataTransferObjects;
using ToDo.BackEnd.Entities;

namespace ToDo.BackEnd.Mapping;

public static class PriorityMapping
{
  public static PriorityDTO ToDTO(this Priority priority)
  {
    return new PriorityDTO(priority.Id, priority.Value);
  }
}
