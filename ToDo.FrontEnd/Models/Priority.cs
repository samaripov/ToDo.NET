using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.FrontEnd.Models;

public class Priority
{
  [Required(ErrorMessage = "A priority is required.")]
  [MinLength(1, ErrorMessage = "Please select a priority.")]
  public required string Value { get; set; }
}
