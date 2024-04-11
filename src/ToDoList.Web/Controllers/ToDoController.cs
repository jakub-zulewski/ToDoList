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

public class ToDoController(IMediator mediator, IMapper mapper) : Controller
{
	private readonly IMediator _mediator = mediator;
	private readonly IMapper _mapper = mapper;

	public async Task<IActionResult> Index(DateOnly? date)
	{
		if (!date.HasValue)
		{
			return View(await _mediator.Send(new GetAllToDoItemsQuery()));
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

		return RedirectToAction(nameof(Index));
	}

	[HttpPost]
	[Route("task/delete/{id:guid}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		await _mediator.Send(new DeleteToDoItemCommand(id));

		return RedirectToAction(nameof(Index));
	}
}
