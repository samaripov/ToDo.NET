using System;

namespace ToDo.BackEnd.DataTransferObjects;

public record class TaskDTO(
  int Id,
  string Title,
  string Description,
  bool Complete,
  DateTime CreatedAt,
  DateTime CompletedAt
);
