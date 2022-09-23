using Microsoft.AspNetCore.Mvc;

using Networking.Backend.Client;

namespace Networking.Consumer.Spa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;

        private readonly ITodoApi _todoApi;

        private readonly IConfiguration _configuration;

        public TodoController(ITodoApi todoApi, IConfiguration configuration, ILogger<TodoController> logger)
        {
            _logger = logger;
            _configuration = configuration;
            _todoApi = todoApi;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _todoApi.GetTodos());
        }
    }
}