using MediatR;

using Microsoft.AspNetCore.Mvc;

using ToDoList.Application.Commands.CreateToDoItem;
using ToDoList.Application.Queries.GetAllToDoItems;

namespace ToDoList.Web.Controllers;

public class ToDoController(IMediator mediator) : Controller
{
	private readonly IMediator _mediator = mediator;

	public async Task<IActionResult> Index()
	{
		return View(await _mediator.Send(new GetAllToDoItemsQuery()));
	}

	public IActionResult Create()
	{
		return View();
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
}
