using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.FrontEnd.Models;

public class Priority
{
  [Required(ErrorMessage = "Please select a priority.")]
  public required string Value { get; set; }
}
