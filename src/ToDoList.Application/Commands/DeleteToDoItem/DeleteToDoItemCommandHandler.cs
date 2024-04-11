using MediatR;

using ToDoList.Domain.Interfaces;

namespace ToDoList.Application.Commands.DeleteToDoItem;

public class DeleteToDoItemCommandHandler(IToDoItemRepository toDoItemRepository)
	: IRequestHandler<DeleteToDoItemCommand>
{
	private readonly IToDoItemRepository _toDoItemRepository = toDoItemRepository;

	public async Task Handle(DeleteToDoItemCommand request, CancellationToken cancellationToken)
	{
		await _toDoItemRepository.DeleteAsync(request.Id);

		await _toDoItemRepository.SaveChangesAsync();
	}
}
