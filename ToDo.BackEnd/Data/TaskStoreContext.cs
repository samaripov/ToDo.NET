using System;
using Microsoft.EntityFrameworkCore;

namespace ToDo.BackEnd.Data;

public class TaskStoreContext(DbContextOptions<TaskStoreContext> options) : DbContext(options)
{
  public DbSet<Entities.Task> Tasks => Set<Entities.Task>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.Entity<Entities.Priority>().HasData(
      new
      {
        Id = 1,
        Value = "High"
      },
      new
      {
        Id = 2,
        Value = "Medium"
      },
      new
      {
        Id = 3,
        Value = "Low"
      }
    );
  }
}
