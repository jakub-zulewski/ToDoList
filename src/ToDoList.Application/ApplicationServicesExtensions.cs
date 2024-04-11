using FluentValidation;
using FluentValidation.AspNetCore;

using Microsoft.Extensions.DependencyInjection;

using ToDoList.Application.Commands.CreateToDoItem;
using ToDoList.Application.Mappings;

namespace ToDoList.Application;

public static class ApplicationServicesExtensions
{
	public static void AddApplicationServices(this IServiceCollection services)
	{
		services.AddMediatR(configuration =>
		{
			configuration.RegisterServicesFromAssembly(
				typeof(ApplicationServicesExtensions).Assembly);
		});

		services.AddAutoMapper(typeof(ToDoItemMappingProfile));

		services.AddValidatorsFromAssemblyContaining<CreateToDoItemCommandValidator>()
			.AddFluentValidationAutoValidation()
			.AddFluentValidationClientsideAdapters();
	}
}
