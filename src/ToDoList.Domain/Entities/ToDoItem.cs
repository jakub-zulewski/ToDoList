namespace ToDoList.Domain.Entities;

public class ToDoItem : BaseEntity
{
	public string Title { get; set; } = default!;

	public string? Description { get; set; }

	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

	public DateTime DueDate { get; set; }

	public bool IsCompleted { get; set; }

	public DateTime? CompletedAt { get; set; }
}
