using AutoMapper;

using MediatR;

using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Application.Commands.CreateToDoItem;

public class CreateToDoItemCommandHandler(IToDoItemRepository toDoItemRepository, IMapper mapper)
	: IRequestHandler<CreateToDoItemCommand>
{
	private readonly IToDoItemRepository _toDoItemRepository = toDoItemRepository;
	private readonly IMapper _mapper = mapper;

	public async Task Handle(CreateToDoItemCommand request, CancellationToken cancellationToken)
	{
		await _toDoItemRepository.Create(_mapper.Map<ToDoItem>(request));

		await _toDoItemRepository.SaveChangesAsync();
	}
}
