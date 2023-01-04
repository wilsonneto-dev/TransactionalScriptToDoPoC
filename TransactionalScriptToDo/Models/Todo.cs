using Microsoft.AspNetCore.Mvc;

namespace TransactionalScriptToDo.Models;

public class Todo
{
    [BindProperty]
    public Guid Id { get; set; }
    public string Description { get; set; } = "";
    public bool IsComplete { get; set; }
}
