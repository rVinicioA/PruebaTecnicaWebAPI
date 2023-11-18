using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaAPI.Context;
using PruebaTecnicaAPI.Models;

namespace PruebaTecnicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoTasksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TodoTasksController(AppDbContext context)
        {
            _context = context;
        }



        // GET: api/TodoTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoTask>>> GetTodoTask()
        {
            if (_context.TodoTask == null)
            {
                return NotFound();
            }
            return await _context.TodoTask.ToListAsync();
        }

        // GET: api/TodoTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoTask>> GetTodoTask(int id)
        {
            if (_context.TodoTask == null)
            {
                return NotFound();
            }
            var value = await _context.TodoTask.FindAsync(id);

            if (value == null)
            {
                return NotFound();
            }

            return value;
        }

        // PUT: api/TodoTasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoTask(int id, TodoTask value)
        {
            if (id != value.Id)
            {
                return BadRequest();
            }

            _context.Entry(value).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoTaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoTask>> PostTodoTask(TodoTask value)
        {
            if (_context.TodoTask == null)
            {
                return Problem("Entity set 'AppDbContext.TodoTask'  is null.");
            }
            value.CreationDate = DateTime.UtcNow;
            _context.TodoTask.Add(value);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoTask", new { id = value.Id }, value);
        }


        // DELETE: api/TodoTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoTask(int id)
        {
            if (_context.TodoTask == null)
            {
                return NotFound();
            }
            var value = await _context.TodoTask.FindAsync(id);
            if (value == null)
            {
                return NotFound();
            }

            _context.TodoTask.Remove(value);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoTaskExists(int id)
        {
            return (_context.TodoTask?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
