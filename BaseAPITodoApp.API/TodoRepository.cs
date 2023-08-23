using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BaseAPITodoApp.API;

public class TodoRepository: ITodoRepository
{
    private readonly TodoAppContext _context;

    public TodoRepository(TodoAppContext context)
    {
        _context = context;
    }

    public IQueryable<Todo> GetAll()
    {
        return _context.Todos;
    }

    public async Task<bool> AddProductAsync(Todo todo)
    {
       await _context.Todos.AddAsync(todo);
       return true;
    }

    public async Task<bool> RemoveAsync(string id)
    {
        var model = await _context.Todos.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        return model != null && Remove(model);
    }

    public bool Remove(Todo todo)
    {
        _context.Todos.Remove(todo);
        return true;
    }

    public bool Update(Todo todo)
    {
        _context.Todos.Update(todo);
        return true;
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task<Todo?> GetByIdAsync(string id)
    {
        var model = await _context.Todos.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        return model;
    }
}