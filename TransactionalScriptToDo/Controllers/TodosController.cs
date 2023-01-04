using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransactionalScriptToDo.Models;

namespace TransactionalScriptToDo.Controllers;

[ApiController]
[Route("[controller]")]
public class TodosController : ControllerBase
{
    private readonly AppContext _context;

    public TodosController(AppContext context) => _context = context;

    [HttpPost]
    public async Task<ActionResult> Create(Todo item)
    {
        _context.Todos.Add(item);
        await _context.SaveChangesAsync();
        return Created(nameof(GetById), new { id = item.Id });
    }

    [HttpPut("{Todo.id:guid}")]
    public async Task<ActionResult> Update(Todo item)
    {
        _context.Todos.Add(item);
        await _context.SaveChangesAsync();
        return Created(nameof(GetById), new { id = item.Id });
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Todo>> GetById(Guid id)
    {
        var item = await _context.Todos.FirstOrDefaultAsync(x => x.Id.Equals(id));
        return item == null ? NotFound() : Ok(item);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Todo>>> List() => await _context.Todos.ToListAsync();
}
