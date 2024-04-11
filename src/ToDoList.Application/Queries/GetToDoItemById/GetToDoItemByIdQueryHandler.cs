using AutoMapper;

using MediatR;

using ToDoList.Application.DTOs.ToDo;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Application.Queries.GetToDoItemById;

public class GetToDoItemByIdQueryHandler(IToDoItemRepository toDoItemRepository, IMapper mapper)
	: IRequestHandler<GetToDoItemByIdQuery, ToDoItemDTO>
{
	private readonly IToDoItemRepository _toDoItemRepository = toDoItemRepository;
	private readonly IMapper _mapper = mapper;

	public async Task<ToDoItemDTO> Handle(
		GetToDoItemByIdQuery request, CancellationToken cancellationToken)
	{
		return _mapper.Map<ToDoItemDTO>(await _toDoItemRepository.GetByIdAsync(request.Id));
	}
}
