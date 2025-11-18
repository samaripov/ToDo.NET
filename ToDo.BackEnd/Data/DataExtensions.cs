using System;
using Microsoft.EntityFrameworkCore;

namespace ToDo.BackEnd.Data;

public static class DataExtensions
{
  public static void MigrateDB(this WebApplication app)
  {
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<TaskStoreContext>();
    dbContext.Database.Migrate();
  }
}
