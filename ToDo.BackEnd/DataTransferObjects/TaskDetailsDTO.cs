using System;

namespace ToDo.BackEnd.DataTransferObjects;

public record class TaskDetailsDTO(
  int Id,
  string Title,
  string Description,
  int PriorityId,
  bool Complete,
  DateTime CreatedAt,
  DateTime CompletedAt
);
