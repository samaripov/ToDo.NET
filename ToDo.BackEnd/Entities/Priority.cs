using System;

namespace ToDo.BackEnd.Entities;

public class Priority
{
  public int Id { get; set; }
  public required string Value { get; set; }
}
