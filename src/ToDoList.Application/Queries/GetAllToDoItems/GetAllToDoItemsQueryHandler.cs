using AutoMapper;

using MediatR;

using ToDoList.Application.DTOs.ToDo;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Application.Queries.GetAllToDoItems;

public class GetAllToDoItemsQueryHandler(IToDoItemRepository toDoItemRepository, IMapper mapper)
	: IRequestHandler<GetAllToDoItemsQuery, IEnumerable<ToDoItemDTO>>
{
	private readonly IToDoItemRepository _toDoItemRepository = toDoItemRepository;
	private readonly IMapper _mapper = mapper;

	public async Task<IEnumerable<ToDoItemDTO>> Handle(
		GetAllToDoItemsQuery request, CancellationToken cancellationToken)
	{
		return _mapper.Map<IEnumerable<ToDoItemDTO>>(await _toDoItemRepository.GetAll());
	}
}
