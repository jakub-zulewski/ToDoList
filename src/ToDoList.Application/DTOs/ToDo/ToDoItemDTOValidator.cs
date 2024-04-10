using FluentValidation;

namespace ToDoList.Application.DTOs.ToDo;

public class ToDoItemDTOValidator : AbstractValidator<ToDoItemDTO>
{
	public ToDoItemDTOValidator()
	{
		RuleFor(x => x.Title)
			.NotEmpty().WithMessage("Title cannot be empty.")
			.MinimumLength(3).WithMessage("Min 3 characters.")
			.MaximumLength(30).WithMessage("Max 30 characters.");

		RuleFor(x => x.Description)
			.MaximumLength(100).WithMessage("Max 100 characters.");

		RuleFor(x => x.DueDate)
			.Custom((value, context) =>
			{
				if (value < DateOnly.FromDateTime(DateTime.UtcNow))
				{
					context.AddFailure("The date cannot be earlier than today.");
				}
			});
	}
}
