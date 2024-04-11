using Microsoft.EntityFrameworkCore;

using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;
using ToDoList.Infrastructure.Persistence;

namespace ToDoList.Infrastructure.Repositories;

internal class ToDoItemRepository(DataContext dataContext) : IToDoItemRepository
{
	private readonly DataContext _dataContext = dataContext;

	public async Task CreateAsync(ToDoItem toDoItem)
	{
		await _dataContext.ToDoItems.AddAsync(toDoItem);
	}

	public async Task DeleteAsync(Guid id)
	{
		var toDoItem = await GetByIdAsync(id);

		_dataContext.ToDoItems.Remove(toDoItem);
	}

	public async Task<IEnumerable<ToDoItem>> GetAllAsync()
	{
		return await _dataContext.ToDoItems
			.OrderBy(x => x.DueDate)
			.ToListAsync();
	}

	public async Task<IEnumerable<ToDoItem>> GetAllByDateAsync(DateOnly dateOnly)
	{
		return await _dataContext.ToDoItems
			.Where(x => x.DueDate == dateOnly)
			.OrderBy(x => x.IsCompleted)
			.ToListAsync();
	}

	public async Task<ToDoItem> GetByIdAsync(Guid id)
	{
		return await _dataContext.ToDoItems.FirstAsync(x => x.Id == id);
	}

	public async Task SaveChangesAsync()
	{
		await _dataContext.SaveChangesAsync();
	}
}
