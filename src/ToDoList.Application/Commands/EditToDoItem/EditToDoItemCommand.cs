using MediatR;

using ToDoList.Application.DTOs.ToDo;

namespace ToDoList.Application.Commands.EditToDoItem;

public class EditToDoItemCommand : ToDoItemDTO, IRequest
{
}
