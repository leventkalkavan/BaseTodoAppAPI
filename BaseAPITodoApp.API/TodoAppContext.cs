using Microsoft.EntityFrameworkCore;

namespace BaseAPITodoApp.API;

public class TodoAppContext: DbContext
{
    public TodoAppContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Todo> Todos { get; set; }
}