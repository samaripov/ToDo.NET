namespace ToDo.FrontEnd.Clients;

public class TasksClient
{
  private readonly List<Models.Task> tasks =
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

  public List<Models.Task> GetTasks() => tasks;

  public void AddTask(Models.Task taskToAdd) 
  {
    ArgumentException.ThrowIfNullOrWhiteSpace(taskToAdd.Priority);
    taskToAdd.Id = tasks.Count > 0 ? tasks.Count + 1 : 1;
    tasks.Add(taskToAdd);
  }
}
