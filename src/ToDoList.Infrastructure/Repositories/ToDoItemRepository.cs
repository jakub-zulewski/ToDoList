﻿using Microsoft.EntityFrameworkCore;

using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;
using ToDoList.Infrastructure.Persistence;

namespace ToDoList.Infrastructure.Repositories;

internal class ToDoItemRepository(DataContext dataContext) : IToDoItemRepository
{
	private readonly DataContext _dataContext = dataContext;

	public async Task Create(ToDoItem toDoItem)
	{
		await _dataContext.ToDoItems.AddAsync(toDoItem);

		await _dataContext.SaveChangesAsync();
	}

	public async Task<IEnumerable<ToDoItem>> GetAll()
	{
		return await _dataContext.ToDoItems
			.OrderBy(x => x.DueDate)
			.ToListAsync();
	}
}
