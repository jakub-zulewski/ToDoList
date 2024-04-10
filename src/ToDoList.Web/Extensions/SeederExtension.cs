using ToDoList.Infrastructure.Seeders;

namespace ToDoList.Web.Extensions;

internal static class SeederExtension
{
	internal static async Task SeedData(this WebApplication webApplication)
	{
		using var scope = webApplication.Services.CreateScope();

		var seeder = scope.ServiceProvider.GetRequiredService<ToDoItemSeeder>();

		await seeder.SeedToDos();
	}
}
