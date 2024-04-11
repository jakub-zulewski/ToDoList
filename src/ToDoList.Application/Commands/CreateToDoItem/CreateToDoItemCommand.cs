using MediatR;

using ToDoList.Application.DTOs.ToDo;

namespace ToDoList.Application.Commands.CreateToDoItem;

public class CreateToDoItemCommand : ToDoItemDTO, IRequest
{

}
