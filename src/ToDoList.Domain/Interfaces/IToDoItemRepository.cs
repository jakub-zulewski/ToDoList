using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interfaces;

public interface IToDoItemRepository
{
	Task Create(ToDoItem toDoItem);
	Task<IEnumerable<ToDoItem>> GetAll();
	Task<IEnumerable<ToDoItem>> GetAllByDateAsync(DateOnly dateOnly);
	Task<ToDoItem> GetById(Guid id);
	Task DeleteAsync(Guid id);
	Task SaveChangesAsync();
}
