namespace ToDo.BackEnd.DataTransferObjects;

public record class CreateTaskDTO(
  string Title,
  string Description,
  bool Complete,
  DateTime CreatedAt,
  DateTime CompletedAt
);
