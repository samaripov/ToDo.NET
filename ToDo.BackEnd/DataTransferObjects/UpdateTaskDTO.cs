namespace ToDo.BackEnd;

public record class UpdateTaskDTO(
  string Title,
  string Description,
  bool Complete,
  DateTime CreatedAt,
  DateTime CompletedAt
);
