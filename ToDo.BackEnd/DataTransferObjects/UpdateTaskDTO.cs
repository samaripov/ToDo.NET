using System.ComponentModel.DataAnnotations;

namespace ToDo.BackEnd;

public record class UpdateTaskDTO(
  [Required][StringLength(50)] string Title,
  string Description,
  [Required] int PriorityId,
  [Required] bool Complete,
  [Required] DateTime CreatedAt,
  [Required] DateTime CompletedAt
);
