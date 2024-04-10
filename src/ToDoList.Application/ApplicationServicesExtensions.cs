using FluentValidation;
using FluentValidation.AspNetCore;

using Microsoft.Extensions.DependencyInjection;

using ToDoList.Application.DTOs.ToDo;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Mappings;
using ToDoList.Application.Services;

namespace ToDoList.Application;

public static class ApplicationServicesExtensions
{
	public static void AddApplicationServices(this IServiceCollection services)
	{
		services.AddScoped<IToDoItemService, ToDoItemService>();

		services.AddAutoMapper(typeof(ToDoItemMappingProfile));

		services.AddValidatorsFromAssemblyContaining<ToDoItemDTOValidator>()
			.AddFluentValidationAutoValidation()
			.AddFluentValidationClientsideAdapters();
	}
}
