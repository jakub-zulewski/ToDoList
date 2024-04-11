using MediatR;

using ToDoList.Application.DTOs.ToDo;

namespace ToDoList.Application.Queries.GetToDoItemById;

public class GetToDoItemByIdQuery(Guid id) : IRequest<ToDoItemDTO>
{
	public Guid Id { get; private set; } = id;
}
