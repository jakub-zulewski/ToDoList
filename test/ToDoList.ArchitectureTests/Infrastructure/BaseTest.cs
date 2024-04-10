using System.Reflection;

using ToDoList.Application;
using ToDoList.Domain;
using ToDoList.Infrastructure;

namespace ToDoList.ArchitectureTests.Infrastructure;

public abstract class BaseTest
{
	protected static readonly Assembly DomainAssembly = typeof(BaseEntity).Assembly;

	protected static readonly Assembly ApplicationAssembly = typeof(
		ApplicationServicesExtensions).Assembly;

	protected static readonly Assembly InfrastructureAssembly = typeof(
		InfrastructureServicesExtensions).Assembly;

	protected static readonly Assembly WebAssembly = typeof(Program).Assembly;
}
