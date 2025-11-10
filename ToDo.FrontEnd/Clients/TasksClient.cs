namespace ToDo.FrontEnd.Clients;

public class TasksClient
{
  private readonly Models.Task[] tasks =
  [
  new() {
      Id = 1,
      Title = "Clean the dishes",
      Description = "The sink is way too full... A quick brown fox jumps over the lazy dogThe sink is way too full... A quick brown fox jumps over the lazy dogThe sink is way too full... A quick brown fox jumps over the lazy dogThe sink is way too full... A quick brown fox jumps over the lazy dog",
      Complete = false,
      Priority = "High"
    },
    new() {
      Id = 2,
      Title = "Make bed",
      Description = "It's messy",
      Complete = true,
      Priority = "Medium"
    },
    new() {
      Id = 3,
      Title = "Finish work",
      Complete = false,
      Priority = "Low"
    }
  ];

  public Models.Task[] GetTasks() => tasks;
}
