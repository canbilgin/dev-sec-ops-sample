using System.Text;

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

using Microsoft.AspNetCore.Mvc;

using Networking.Backend.Client;

using Refit;

namespace Networking.Backend.Api.Controllers
{
    [ApiController]
    [Route("todos")]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;

        private readonly ITodoApi _todoApi;

        private readonly string _blobConnectionString;

        public TodoController(ITodoApi todoApi, IConfiguration configuration, ILogger<TodoController> logger)
        {
            _logger = logger;
            _todoApi = todoApi;
            _blobConnectionString = configuration["Blobs"];
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (!string.IsNullOrWhiteSpace(this._blobConnectionString))
            {
                BlobContainerClient blobContainerClient = new BlobContainerClient(_blobConnectionString, "todos");
                var blobClient = blobContainerClient.GetBlobClient($"blob-{new Random().Next(0, 500)}");

                using var blob = await blobClient.OpenWriteAsync(true);

                await blob.WriteAsync(Encoding.UTF8.GetBytes("test"));
            }

            return Ok(await _todoApi.GetTodos());
        }
    }
}