using Microsoft.EntityFrameworkCore;

namespace BaseAPITodoApp.API;

public static class ServiceRegistration
{
    public static void AddRegistrationServices(this IServiceCollection services)
    {
        services.AddDbContext<TodoAppContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString));
        services.AddScoped<ITodoRepository, TodoRepository>();
    }
}