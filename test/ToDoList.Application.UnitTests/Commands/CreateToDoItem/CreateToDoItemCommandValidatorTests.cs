﻿using FluentValidation.TestHelper;

using ToDoList.Application.Commands.CreateToDoItem;

namespace ToDoList.Application.UnitTests.Commands.CreateToDoItem;

public class EditToDoItemCommandValidatorTests
{
	[Fact]
	public void CreateToDoItemValidator_WithValidCommand_ShouldNotHaveAnyValidationErrors()
	{
		var validator = new CreateToDoItemCommandValidator();

		var command = new CreateToDoItemCommand()
		{
			Title = "Title",
			Description = "Description",
			DueDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(1)),
		};

		var result = validator.TestValidate(command);

		result.ShouldNotHaveAnyValidationErrors();
	}

	[Fact]
	public void CreateToDoItemValidator_WithInvalidCommand_ShouldHaveValidationErrors()
	{
		var validator = new CreateToDoItemCommandValidator();

		var command = new CreateToDoItemCommand()
		{
			Title = "",
			Description = "Description"
		};

		var result = validator.TestValidate(command);

		result.ShouldHaveValidationErrorFor(x => x.Title);
		result.ShouldHaveValidationErrorFor(x => x.DueDate);
	}
}
