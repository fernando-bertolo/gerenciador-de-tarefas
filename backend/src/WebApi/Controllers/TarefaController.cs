using Microsoft.AspNetCore.Mvc;

namespace backend.src.WebApi.Controllers
{
    [ApiController] // Indica que é uma API Controller
    [Route("api/[controller]")] // Rota base: api/hello
    public class TarefaController : ControllerBase
    {
        [HttpGet] // GET api/hello
        public IActionResult GetHello()
        {
            return Ok("Hello World!");
        }

        [HttpGet("greet/{name}")] // GET api/hello/greet/fernando
        public IActionResult Greet(string name)
        {
            return Ok($"Hello, {name}!");
        }

        [HttpPost] // POST api/hello
        public IActionResult PostHello([FromBody] string message)
        {
            return Ok($"Received: {message}");
        }
    }
}
