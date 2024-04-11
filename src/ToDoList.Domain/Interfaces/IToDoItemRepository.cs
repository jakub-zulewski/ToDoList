using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interfaces;

public interface IToDoItemRepository
{
	Task CreateAsync(ToDoItem toDoItem);
	Task<IEnumerable<ToDoItem>> GetAllAsync();
	Task<IEnumerable<ToDoItem>> GetAllByDateAsync(DateOnly dateOnly);
	Task<ToDoItem> GetByIdAsync(Guid id);
	Task DeleteAsync(Guid id);
	Task SaveChangesAsync();
}
