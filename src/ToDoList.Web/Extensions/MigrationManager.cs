using Microsoft.EntityFrameworkCore;

using ToDoList.Infrastructure.Persistence;

namespace ToDoList.Web.Extensions;

internal static class MigrationManager
{
	internal static async Task MigrateDatabase(this WebApplication webApplication)
	{
		using var scope = webApplication.Services.CreateAsyncScope();

		using var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();

		var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

		try
		{
			await dataContext.Database.MigrateAsync();

			logger.LogInformation("Database has been updated!");
		}
		catch
		{
			logger.LogError("An error occurred during migration!");
		}
	}
}
