namespace BaseAPITodoApp.API;

public interface ITodoRepository
{
    IQueryable<Todo> GetAll();
    Task<bool> AddProductAsync(Todo todo);
    Task<bool> RemoveAsync(string id);
    bool Remove(Todo todo);
    bool Update(Todo todo);
    Task<int> SaveAsync();
    Task<Todo> GetByIdAsync(string id);
}