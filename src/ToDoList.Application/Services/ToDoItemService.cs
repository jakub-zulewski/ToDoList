using AutoMapper;

using ToDoList.Application.DTOs.ToDo;
using ToDoList.Application.Interfaces;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Application.Services;

public class ToDoItemService(IToDoItemRepository toDoItemRepository, IMapper mapper)
	: IToDoItemService
{
	private readonly IToDoItemRepository _toDoItemRepository = toDoItemRepository;
	private readonly IMapper _mapper = mapper;

	public async Task Create(ToDoItemDTO toDoItemDTO)
	{
		await _toDoItemRepository.Create(_mapper.Map<ToDoItem>(toDoItemDTO));
	}

	public async Task<IEnumerable<ToDoItemDTO>> GetAll()
	{
		return _mapper.Map<IEnumerable<ToDoItemDTO>>(await _toDoItemRepository.GetAll());
	}
}
