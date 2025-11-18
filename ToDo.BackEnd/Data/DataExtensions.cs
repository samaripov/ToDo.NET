using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDo.BackEnd.Data;

public static class DataExtensions
{
  public static async Task MigrateDBAsync(this WebApplication app)
  {
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<TaskStoreContext>();
    await dbContext.Database.MigrateAsync();
  }
}
