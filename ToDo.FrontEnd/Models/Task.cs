using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.FrontEnd.Models;

public class Task
{
  [Key]
  public int Id { get; set; }
  [MinLength(2, ErrorMessage = "Title must be at least 2 characters long.")]
  public required string Title { get; set; }
  public string Description { get; set; } = string.Empty;
  public bool Complete { get; set; } = false;
  
  [Required(ErrorMessage = "A priority is required.")]
  public required Models.Priority Priority { get; set; }
  public DateTime CreatedAt { get; set; }  
  public DateTime? CompletedAt { get; set; }

  public override string ToString() 
  {
    return $"""
            -------------------
            ID: {Id}
            Title: "{Title}"
            Description: "{AbbreviateDescription()}"
            Priority: {Priority.Value}
          """;
  }
  public string AbbreviateDescription() 
  {
    var maxLength = 30;
    return Description.Length > maxLength ? Description.Substring(0, maxLength) + "..." : Description;
  }
}
