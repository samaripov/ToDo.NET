using System.ComponentModel.DataAnnotations;

namespace ToDo.BackEnd;

public record class UpdateTaskDTO(
  [Required][MaxLength(50)] string Title,
  string Description,
  [Required] bool Complete,
  [Required] DateTime CreatedAt,
  [Required] DateTime CompletedAt
);
