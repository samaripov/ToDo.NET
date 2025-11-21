namespace ToDo.FrontEnd.Clients;

public class TasksClient(HttpClient httpClient)
{
  public Uri url = httpClient.BaseAddress;
  private readonly Models.Task[] tasks;

  public async Task<Models.Task[]> GetTasksAsync() 
    => await httpClient.GetFromJsonAsync<Models.Task[]>("") ?? [];

  public async void AddTask(Models.Task taskToAdd) 
  {
    ArgumentException.ThrowIfNullOrWhiteSpace(taskToAdd.Title);
    ArgumentException.ThrowIfNullOrWhiteSpace(taskToAdd.Priority.Value);
    var taskDTO = new
    {
      title = taskToAdd.Title,
      description = taskToAdd.Description,
      PriorityId = taskToAdd.Priority.ValueAsNumString()
    };
    Console.WriteLine(taskDTO);
    var response = await httpClient.PostAsJsonAsync("/new", taskDTO);
    response.EnsureSuccessStatusCode();
  }

  public void UpdateTask(Models.Task taskToUpdate) 
  {
    var existingTask = GetTaskById(taskToUpdate.Id);
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
    // return tasks.Find(task => task.Id == taskId);
    return null;
  }
  public Task DeleteTask(int taskId) {
    // tasks.RemoveAll(t => t.Id == taskId);
    return System.Threading.Tasks.Task.CompletedTask;
  }  
}
