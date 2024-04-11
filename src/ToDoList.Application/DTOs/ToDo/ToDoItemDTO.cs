﻿namespace ToDoList.Application.DTOs.ToDo;

public class ToDoItemDTO
{
	public Guid Id { get; set; }
	public required string Title { get; set; } = default!;
	public string? Description { get; set; }
	public DateOnly DueDate { get; set; }
	public bool IsCompleted { get; set; }
}
