using Serilog;

using ToDoList.Application;
using ToDoList.Infrastructure;
using ToDoList.Web.Extensions;

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateBootstrapLogger();

try
{
	Log.Information("Starting To do application.");

	var builder = WebApplication.CreateBuilder(args);

	// Add services to the container.
	builder.Services.AddControllersWithViews();

	builder.Services.AddInfrastructureServices(builder.Configuration);

	builder.Services.AddApplicationServices();

	builder.Host.UseSerilog((context, configuration) =>
	{
		configuration.ReadFrom.Configuration(context.Configuration);
	});

	var app = builder.Build();

	// Configure the HTTP request pipeline.
	if (!app.Environment.IsDevelopment())
	{
		app.UseExceptionHandler("/Home/Error");
		// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
		app.UseHsts();
	}

	app.UseHttpsRedirection();
	app.UseStaticFiles();

	app.UseRouting();

	app.UseAuthorization();

	app.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");

	await app.MigrateDatabase();

	await app.SeedData();

	app.Run();
}
catch (Exception ex)
{
	Log.Fatal(ex, "Application terminated unexpectedly.");
}
finally
{
	Log.CloseAndFlush();
}

// For testing purposes only
public partial class Program;
