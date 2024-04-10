using Microsoft.EntityFrameworkCore;

using ToDoList.Domain.Entities;

namespace ToDoList.Infrastructure.Persistence;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
	public DbSet<ToDoItem> ToDoItems { get; set; }
}
