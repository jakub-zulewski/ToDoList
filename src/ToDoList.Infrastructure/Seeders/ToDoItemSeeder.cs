using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using ToDoList.Domain.Entities;
using ToDoList.Infrastructure.Persistence;

namespace ToDoList.Infrastructure.Seeders;

public class ToDoItemSeeder(DataContext dataContext, ILogger<ToDoItemSeeder> logger)
{
	private readonly DataContext _dataContext = dataContext;
	private readonly ILogger<ToDoItemSeeder> _logger = logger;

	public async Task SeedToDos()
	{
		if (!await _dataContext.Database.CanConnectAsync())
		{
			_logger.LogError("Can't connect to database!");

			return;
		}

		if (await _dataContext.ToDoItems.AnyAsync())
		{
			_logger.LogInformation("To do items already exist in database. Skipping seed data.");

			return;
		}

		var toDos = new List<ToDoItem>
		{
			new() {
				Title = "To do task 1. Title.",
				Description = "To do task 1. Description.",
				CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow),
				DueDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(2))
			},
			new() {
				Title = "To do task 2. Title.",
				Description = "To do task 2. Description.",
				CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow),
				DueDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(5))
			},
			new() {
				Title = "To do task 3 completed. Title.",
				Description = "To do task 3 completed. Description.",
				CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow),
				DueDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-1)),
				IsCompleted = true
			}
		};

		await _dataContext.ToDoItems.AddRangeAsync(toDos);

		await _dataContext.SaveChangesAsync();

		_logger.LogInformation("Data seeded successfully!");
	}
}
