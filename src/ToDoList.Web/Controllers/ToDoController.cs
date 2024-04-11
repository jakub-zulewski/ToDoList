using Microsoft.AspNetCore.Mvc;

using ToDoList.Application.DTOs.ToDo;
using ToDoList.Application.Interfaces;

namespace ToDoList.Web.Controllers;

public class ToDoController(IToDoItemService toDoItemService) : Controller
{
	private readonly IToDoItemService _toDoItemService = toDoItemService;

	public async Task<IActionResult> Index()
	{
		return View(await _toDoItemService.GetAll());
	}

	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Create(ToDoItemDTO toDoItemDTO)
	{
		if (!ModelState.IsValid)
		{
			return View();
		}

		await _toDoItemService.Create(toDoItemDTO);

		return RedirectToAction(nameof(Index));
	}
}
