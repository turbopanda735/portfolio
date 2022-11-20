using movieProject.Models.Movie;

namespace movieProject.Models.Todo
{
    public interface ITodoRepository
    {
        public IEnumerable<TodoModel> GetAllTodo();
        public TodoModel GetIdTodo(int id);
        public void DeleteTodo(int id);
        public void PutTodo(TodoModel todo);
        public void PostTodo(TodoModel todo);
    }
}
