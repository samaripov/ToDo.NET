using System;

namespace ToDo.FrontEnd.Models;

public class ToDo
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool Complete { get; set; } = false;
    public readonly DateTime CreatedAt = DateTime.Now;
    public DateTime CompletedAt { get; set; }
}
