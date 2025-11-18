using System;
using Microsoft.EntityFrameworkCore;
using ToDo.BackEnd.Data;
using ToDo.BackEnd.Mapping;

namespace ToDo.BackEnd.Endpoints;

public static class PriorityEndpoints
{
  public static RouteGroupBuilder MapPrioritiesEndpoints(this WebApplication app)
  {
    var group = app.MapGroup("priorities");

    group.MapGet("/", async (TaskStoreContext dbContext) => 
      await dbContext.Priorities
              .Select((priority) => priority.ToDTO())
              .AsNoTracking()
              .ToListAsync()
    );
    
    return group;
  }
}
