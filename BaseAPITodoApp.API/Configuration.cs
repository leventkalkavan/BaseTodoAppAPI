namespace BaseAPITodoApp.API;

public class Configuration
{
    public static string? GetConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),
                "/Users/leventkalkavan/Desktop/Projeler/BaseTodoApp/BaseAPITodoApp.API"));
            configurationManager.AddJsonFile("appsettings.json");

            return configurationManager.GetConnectionString("Mssql");
        }
    }
}