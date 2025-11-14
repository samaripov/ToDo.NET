using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.FrontEnd.Models;

public class Task
{
  public int Id { get; set; }
  [MinLength(2, ErrorMessage = "Title must be at least 3 characters long.")]
  public required string Title { get; set; }
  public string Description { get; set; } = string.Empty;
  public bool Complete { get; set; } = false;
  
  [Required(ErrorMessage = "Please select a priority.")]
  public string? Priority { get; set; }
  public readonly DateTime CreatedAt = DateTime.Now;
  public DateTime CompletedAt { get; set; }

  public string ToString() 
  {
    return $"""
            -------------------
            ID: {Id}
            Title: "{Title}"
            Description: "{AbbreviateDescription()}"
            Priority: {Priority}
          """;
  }
  public string AbbreviateDescription() 
  {
    var maxLength = 30;
    return Description.Length > maxLength ? Description.Substring(0, maxLength) + "..." : Description;
  }
}
