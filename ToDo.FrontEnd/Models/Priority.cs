using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.FrontEnd.Models;

public class Priority
{
  [Required(AllowEmptyStrings = false, ErrorMessage = "Please select a priority.")]
  public required string Value { get; set; }
}
