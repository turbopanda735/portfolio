using DocumentFormat.OpenXml.Office2010.Excel;
using movieProject.Controllers;
using MySqlX.XDevAPI;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json;

namespace movieProject.Models.Todo
{
    public class TodoRepository : ITodoRepository
    {
        private static readonly HttpClient _client = new HttpClient()
        {
            BaseAddress = new Uri("https://joelkozek.com/")
        };
        public void DeleteTodo(int id)
        {
            _client.DeleteAsync($"api/todo/{id}");
        }
        public IEnumerable<TodoModel> GetAllTodo()
        {
            var response = _client.GetStringAsync("api/todo").Result;
            var result = JToken.Parse(response);
            var allTodo = new List<TodoModel>();
            foreach (var item in result)
            {
                var todo = new TodoModel()
                {
                    Name = item["name"].ToString(),
                    Id = Convert.ToInt32(item["id"]),
                    IsComplete = Convert.ToBoolean(item["isComplete"])
                };
                allTodo.Add(todo);
            }
            return allTodo;
        }

        public TodoModel GetIdTodo(int id)
        {
            var response = _client.GetStringAsync("api/todo").Result;
            var result = JToken.Parse(response);
            try
            {
                foreach (var item in result)
                {
                    var todo = new TodoModel()
                    {
                        Name = item["name"].ToString(),
                        Id = Convert.ToInt32(item["id"]),
                        IsComplete = Convert.ToBoolean(item["isComplete"])
                    };
                    if (todo.Id == id)
                    {
                        return todo;
                    }                
                }
                return new TodoModel()
                {
                    Name = "an error has occured"
                };
            }
            catch (Exception)
            {
                return new TodoModel()
                {
                    Name = "an error has occured"
                };
            }
        }

        public void PostTodo(TodoModel todo)
        {
            using StringContent jsonContent = new(
            JsonSerializer.Serialize(new
            {
                todo.Name,
                todo.Id,
                todo.IsComplete
            }),
            Encoding.UTF8,
            "application/json");
            _client.PostAsync($"api/todo/{todo.Id}", jsonContent);
        }

        public void PutTodo(TodoModel todo)
        {
            using StringContent jsonContent = new(JsonSerializer.Serialize(todo), Encoding.UTF8, "application/json");
            _client.PutAsync($"api/todo/{todo.Id}", jsonContent);
        }
    }
}
