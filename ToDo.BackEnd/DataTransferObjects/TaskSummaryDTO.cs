using System;

namespace ToDo.BackEnd.DataTransferObjects;

public record class TaskSummaryDTO(
  int Id,
  string Title,
  string Description,
  PriorityDTO Priority,
  bool Complete,
  DateTime CreatedAt,
  DateTime? CompletedAt
);
