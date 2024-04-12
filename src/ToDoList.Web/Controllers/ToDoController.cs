using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using ToDoList.Application.Commands.CreateToDoItem;
using ToDoList.Application.Commands.DeleteToDoItem;
using ToDoList.Application.Commands.EditToDoItem;
using ToDoList.Application.Queries.GetAllToDoItems;
using ToDoList.Application.Queries.GetAllToDoItemsByDate;
using ToDoList.Application.Queries.GetToDoItemById;

namespace ToDoList.Web.Controllers;

public class ToDoController(IMediator mediator, IMapper mapper, ILogger<ToDoController> logger)
	: Controller
{
	private readonly IMediator _mediator = mediator;
	private readonly IMapper _mapper = mapper;
	private readonly ILogger<ToDoController> _logger = logger;

	public async Task<IActionResult> Index(DateOnly? date)
	{
		if (!date.HasValue)
		{
			var toDos = await _mediator.Send(new GetAllToDoItemsQuery());

			var toDoItemsCount = toDos
				.Where(x => x.DueDate == DateOnly.FromDateTime(DateTime.UtcNow.AddDays(1)) &&
					x.IsCompleted == false)
				.Count();

			if (toDoItemsCount > 0)
			{
				ViewBag.Tasks = $"You have {toDoItemsCount} tasks planned for tomorrow!";
			}
			else
			{
				ViewBag.Tasks = null;
			}

			return View(toDos);
		}

		ViewBag.Date = date.Value;

		return View(await _mediator.Send(new GetAllToDoItemByDateQuery(date.Value)));
	}

	public IActionResult Create()
	{
		return View();
	}

	[Route("task/details/{id:guid}")]
	public async Task<IActionResult> Details(Guid id)
	{
		return View(await _mediator.Send(new GetToDoItemByIdQuery(id)));
	}

	[Route("task/edit/{id:guid}")]
	public async Task<IActionResult> Edit(Guid id)
	{
		var toDoItemDTO = await _mediator.Send(new GetToDoItemByIdQuery(id));

		var model = _mapper.Map<EditToDoItemCommand>(toDoItemDTO);

		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreateToDoItemCommand createToDoItemCommand)
	{
		if (!ModelState.IsValid)
		{
			return View();
		}

		await _mediator.Send(createToDoItemCommand);

		_logger.LogInformation($"Task {createToDoItemCommand.Title} has been created.");

		return RedirectToAction(nameof(Index));
	}

	[HttpPost]
	[Route("task/edit/{id:guid}")]
	public async Task<IActionResult> Edit(Guid id, EditToDoItemCommand editToDoItemCommand)
	{
		if (!ModelState.IsValid)
		{
			return View(editToDoItemCommand);
		}

		await _mediator.Send(editToDoItemCommand);

		_logger.LogInformation($"Task {editToDoItemCommand.Id} has been edited.");

		return RedirectToAction(nameof(Index));
	}

	[HttpPost]
	[Route("task/delete/{id:guid}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		await _mediator.Send(new DeleteToDoItemCommand(id));

		_logger.LogInformation($"Task {id} has been deleted.");

		return RedirectToAction(nameof(Index));
	}
}
