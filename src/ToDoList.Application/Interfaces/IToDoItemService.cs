using ToDoList.Application.DTOs.ToDo;

namespace ToDoList.Application.Interfaces;

public interface IToDoItemService
{
	Task Create(ToDoItemDTO toDoItemDTO);
}