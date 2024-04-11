using AutoMapper;

using MediatR;

using ToDoList.Application.DTOs.ToDo;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Application.Queries.GetAllToDoItemsByDate;

public class GetAllToDoItemByDateHandler(IToDoItemRepository toDoItemRepository, IMapper mapper)
	: IRequestHandler<GetAllToDoItemByDateQuery, IEnumerable<ToDoItemDTO>>
{
	private readonly IToDoItemRepository _toDoItemRepository = toDoItemRepository;
	private readonly IMapper _mapper = mapper;

	public async Task<IEnumerable<ToDoItemDTO>> Handle(
		GetAllToDoItemByDateQuery request, CancellationToken cancellationToken)
	{
		return _mapper.Map<IEnumerable<ToDoItemDTO>>(
			await _toDoItemRepository.GetAllByDateAsync(request.DateOnly));
	}
}
