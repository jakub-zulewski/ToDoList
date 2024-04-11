using MediatR;

namespace ToDoList.Application.Commands.DeleteToDoItem;

public class DeleteToDoItemCommand(Guid id) : IRequest
{
	public Guid Id { get; private set; } = id;
}
