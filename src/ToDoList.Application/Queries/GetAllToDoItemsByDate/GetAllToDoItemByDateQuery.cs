using MediatR;

using ToDoList.Application.DTOs.ToDo;

namespace ToDoList.Application.Queries.GetAllToDoItemsByDate;

public class GetAllToDoItemByDateQuery(DateOnly dateOnly) : IRequest<IEnumerable<ToDoItemDTO>>
{
	public DateOnly DateOnly { get; private set; } = dateOnly;
}
