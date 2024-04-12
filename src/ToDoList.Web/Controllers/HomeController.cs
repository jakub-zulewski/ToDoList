using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using ToDoList.Web.Models;

namespace ToDoList.Web.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
	private readonly ILogger<HomeController> _logger = logger;

	public IActionResult Index()
	{
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		_logger.LogError($"Request Id: {Activity.Current?.Id}, Trace Identifier: {HttpContext.TraceIdentifier}");

		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}
