namespace ToDoList.Domain;

public abstract class BaseEntity
{
	public required Guid Id { get; set; }
}
