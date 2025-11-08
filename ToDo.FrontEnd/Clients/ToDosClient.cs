namespace ToDo.FrontEnd.Clients;
using ToDo.FrontEnd.Models;

public class ToDosClient
{
  private List<ToDo> toDos =
  [
  new() {
      Id = 1,
      Title = "Clean the dishes",
      Description = "The sink is way too full...",
      Complete = false
    },
    new() {
      Id = 2,
      Title = "Make bed",
      Description = "It's messy",
      Complete = true
    },
    new() {
      Id = 3,
      Title = "Finish work",
      Complete = false
    }
  ];
}
