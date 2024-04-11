using AutoMapper;

using ToDoList.Application.DTOs.ToDo;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Mappings;

internal class ToDoItemMappingProfile : Profile
{
	public ToDoItemMappingProfile()
	{
		CreateMap<ToDoItemDTO, ToDoItem>();

		CreateMap<ToDoItem, ToDoItemDTO>();
	}
}
