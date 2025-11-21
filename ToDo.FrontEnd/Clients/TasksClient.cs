namespace ToDo.FrontEnd.Clients;

public class TasksClient(HttpClient httpClient)
{
  public async System.Threading.Tasks.Task<Models.Task[]> GetTasksAsync() 
    => await httpClient.GetFromJsonAsync<Models.Task[]>("/tasks") ?? [];

  public async System.Threading.Tasks.Task AddTaskAsync(Models.Task taskToAdd) 
  {
    ArgumentException.ThrowIfNullOrWhiteSpace(taskToAdd.Title);
    ArgumentException.ThrowIfNullOrWhiteSpace(taskToAdd.Priority.Value);
    var taskDTO = new
    {
      taskToAdd.Title,
      taskToAdd.Description,
      PriorityId = taskToAdd.Priority.ValueAsNumString(),
      CreatedAt = DateTime.Now
    };
    var response = await httpClient.PostAsJsonAsync("/tasks/new", taskDTO);
    response.EnsureSuccessStatusCode();
  }

  public async System.Threading.Tasks.Task UpdateTaskAsync(Models.Task taskToUpdate) 
  {
    var existingTask = GetTaskByIdAsync(taskToUpdate.Id);
    if (existingTask != null)
    {
      var taskDTO = new 
      {
        taskToUpdate.Title,
        taskToUpdate.Description,
        PriorityId = taskToUpdate.Priority.ValueAsNumString(),
        taskToUpdate.Complete,
        taskToUpdate.CompletedAt
      };
      var response = await httpClient.PutAsJsonAsync($"/tasks/{taskToUpdate.Id}/edit", taskDTO);
      response.EnsureSuccessStatusCode();
    }
  }

  public List<Models.Task>? GetTasksByPriority(Boolean reverse = false)
  {
    // var sortedTasks = tasks.OrderBy(task => convertPriorityToInt(task.Priority.Value));
    // if (reverse)
    // {
    //   return sortedTasks.Reverse().ToList();
    // }
    // return sortedTasks.ToList();
    return null;
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
  public async System.Threading.Tasks.Task<Models.Task?> GetTaskByIdAsync(int taskId) 
  => await httpClient.GetFromJsonAsync<Models.Task>($"/tasks/{taskId}");
  public Task DeleteTask(int taskId) {
    // tasks.RemoveAll(t => t.Id == taskId);
    return System.Threading.Tasks.Task.CompletedTask;
  }  
}
