using MediatR;

using ToDoList.Application.DTOs.ToDo;

namespace ToDoList.Application.Queries.GetAllToDoItems;

public class GetAllToDoItemsQuery : IRequest<IEnumerable<ToDoItemDTO>>
{
}
