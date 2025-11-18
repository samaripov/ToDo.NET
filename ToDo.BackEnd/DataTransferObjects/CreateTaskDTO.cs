using System.ComponentModel.DataAnnotations;

namespace ToDo.BackEnd.DataTransferObjects;

public record class CreateTaskDTO(
  [Required][StringLength(50)] string Title,
  string Description,
  [Required] int PriorityId,
  [Required] bool Complete,
  [Required] DateTime CreatedAt,
  DateTime? CompletedAt
);
