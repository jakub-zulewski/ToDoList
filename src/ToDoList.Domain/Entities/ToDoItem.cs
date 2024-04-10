namespace ToDoList.Domain.Entities;

public class ToDoItem : BaseEntity
{
	public string Title { get; set; } = default!;

	public string? Description { get; set; }

	public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

	public DateOnly DueDate { get; set; }

	public bool IsCompleted { get; set; }
}
