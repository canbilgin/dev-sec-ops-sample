using Refit;

namespace Networking.Backend.Client
{
    public class Todo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }
    }

    public interface ITodoApi
    {
        [Get("/todos")]
        Task<IEnumerable<Todo>> GetTodos();
    }
}