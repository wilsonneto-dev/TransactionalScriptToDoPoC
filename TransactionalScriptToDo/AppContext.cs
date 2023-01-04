using Microsoft.EntityFrameworkCore;
using TransactionalScriptToDo.Models;

namespace TransactionalScriptToDo;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options) : base(options) 
    {
        Database.EnsureCreated();
    }

    public DbSet<Todo> Todos => Set<Todo>();
}
