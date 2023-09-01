using BrawlFav.DTOs;
using BrawlFav.Models;
using BrawlFav.Services;
using BrawlFav.Services.BrawlFav.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrawlFav.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {

        private readonly ITodoService _todoService;


        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        // GET: TodoController
        [HttpGet("", Name = "GetTodos")]
        public ActionResult<List<Todo>> Index()
        {
            return Ok(_todoService.GetAll());
        }

        // GET: TodoController/5
        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult<Todo> Details([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID");
            }

            var todo = _todoService.Get(id);
            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }


        // POST: TodoController
        [HttpPost("", Name = "Create Todo")]
        public ActionResult<Todo> Create([FromBody] CreateTodoDTO createTodoDTO)
        {
            if (ModelState.IsValid)
            {
                var result = _todoService.Create(createTodoDTO);
                return Created("todos", result);

            }
            return BadRequest(ModelState);

        }



        // PATCH: TodoController/5
        [HttpPatch("{id}", Name = "Update Todo")]
        public ActionResult<int> Edit([FromRoute] int id, [FromBody] UpdateTodoDTO updateTodoDTO)
        {

            if (id <= 0)
            {
                return BadRequest("Invalid ID");
            }

            if (ModelState.IsValid)
            {
                var result = _todoService.Update(id, updateTodoDTO);
                if (result == -1) return NotFound();
                return result;
            }

            return BadRequest(ModelState);
        }


        // DELETE: TodoController/5
        [HttpDelete("{id}", Name = "Delete Todo")]
        public ActionResult<int> Delete([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID");
            }

            var result = _todoService.Delete(id);
            if (result == -1)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
