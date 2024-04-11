using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interfaces;

public interface IToDoItemRepository
{
	Task Create(ToDoItem toDoItem);
	Task<IEnumerable<ToDoItem>> GetAll();
}
