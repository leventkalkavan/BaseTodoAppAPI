namespace BaseAPITodoApp.API;

public class Todo
{
    public Guid Id { get; set; }
    public string Header { get; set; }
    public string? Description { get; set; }
    public bool Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}