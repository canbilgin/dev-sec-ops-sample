using Networking.Backend.Client;
using Networking.Backend.Repository;

namespace Networking.Backend.Service
{
    public class TodoApi : ITodoApi
    {
        private readonly TodoRepository _repository;

        public TodoApi(TodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Todo>> GetTodos()
        {
            await Task.Delay(10);

            return _repository.GetTodos();
        }
    }
}