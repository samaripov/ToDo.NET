namespace ToDo.FrontEnd.Clients;

public class TasksClient
{
  private readonly List<Models.Task> tasks = new List<Models.Task> {
  new Models.Task {
      Id = 1,
      Title = "Clean the dishes",
      Description = "The sink is way too full. A quick brown fox jumps over the lazy dogThe sink is way too full... A quick brown fox jumps over the lazy dogThe sink is way too full... A quick brown fox jumps over the lazy dogThe sink is way too full... A quick brown fox jumps over the lazy dog",
      Complete = false,
      Priority = new Models.Priority{
        Value = "High"
      }
    },
    new Models.Task {
      Id = 2,
      Title = "Make bed",
      Description = "It's messy",
      Complete = true,
      CompletedAt = DateTime.Now,
      Priority = new Models.Priority{
        Value = "Medium"
      }
    },
    new Models.Task {
      Id = 3,
      Title = "Finish work",
      Complete = false,
      Priority = new Models.Priority{
        Value = "Low"
      }
    }
  };

  public List<Models.Task> GetTasks() => tasks;

  public void AddTask(Models.Task taskToAdd) 
  {
    ArgumentException.ThrowIfNullOrWhiteSpace(taskToAdd.Title);
    ArgumentException.ThrowIfNullOrWhiteSpace(taskToAdd.Priority.Value);
    taskToAdd.Id = tasks.Count > 0 ? tasks.Count + 1 : 1;
    tasks.Add(taskToAdd);
  }

  public void UpdateTask(Models.Task taskToUpdate) 
  {
    var existingTask = GetTaskById(taskToUpdate.Id+1);
    Console.WriteLine(existingTask);
    if (existingTask != null)
    {
      existingTask.Title = taskToUpdate.Title;
      existingTask.Description = taskToUpdate.Description;
      existingTask.Priority.Value = taskToUpdate.Priority.Value;
      existingTask.Complete = taskToUpdate.Complete;
      existingTask.CompletedAt = taskToUpdate.CompletedAt;
    }
  }

  public List<Models.Task> GetTasksByPriority(Boolean reverse = false)
  {
    var sortedTasks = tasks.OrderBy(task => convertPriorityToInt(task.Priority.Value));
    if (reverse)
    {
      return sortedTasks.Reverse().ToList();
    }
    return sortedTasks.ToList();
  }

  public int convertPriorityToInt(String priorityString)
  {
    switch(priorityString)
    {
      case "Medium":
        return 2;
      case "Low":
        return 3;
    }
    return 1;
  }
  public string convertIntToPriority(int priorityInt)
  {
    switch(priorityInt)
    {
      case 1:
        return "High";
      case 2:
        return "Medium";
    }
    return "Low";
  }
  public Models.Task? GetTaskById(int taskId) {
    return tasks.Find(task => task.Id == taskId);
  }
  public Task DeleteTask(int taskId) {
    tasks.RemoveAll(t => t.Id == taskId);
    return System.Threading.Tasks.Task.CompletedTask;
  }  
}
