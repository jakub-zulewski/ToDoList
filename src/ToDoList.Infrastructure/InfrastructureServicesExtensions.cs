using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ToDoList.Infrastructure.Persistence;

namespace ToDoList.Infrastructure;

public static class InfrastructureServicesExtensions
{
	public static void AddInfrastructureServices(
		this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<DataContext>(options =>
		{
			options.UseNpgsql(configuration.GetConnectionString("ToDoList"));
		});
	}
}
