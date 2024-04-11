using MediatR;

using ToDoList.Domain.Interfaces;

namespace ToDoList.Application.Commands.EditToDoItem;

public class EditToDoItemHandler(IToDoItemRepository toDoItemRepository)
	: IRequestHandler<EditToDoItemCommand>
{
	private readonly IToDoItemRepository _toDoItemRepository = toDoItemRepository;

	public async Task Handle(EditToDoItemCommand request, CancellationToken cancellationToken)
	{
		var toDoItem = await _toDoItemRepository.GetByIdAsync(request.Id);

		toDoItem.Title = request.Title;
		toDoItem.Description = request.Description;
		toDoItem.IsCompleted = request.IsCompleted;
		toDoItem.DueDate = request.DueDate;

		await _toDoItemRepository.SaveChangesAsync();
	}
}
