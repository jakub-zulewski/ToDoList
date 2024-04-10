namespace ToDoList.Application.DTOs.ToDo;

public class ToDoItemDTO
{
	public required string Title { get; set; } = default!;
	public string? Description { get; set; }
	public DateOnly DueDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
	public bool IsCompleted { get; set; }
}
