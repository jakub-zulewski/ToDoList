using FluentAssertions;

using NetArchTest.Rules;

using ToDoList.ArchitectureTests.Infrastructure;

namespace ToDoList.ArchitectureTests.Projects;

public class ApplicationProjectTests : BaseTest
{
	[Fact]
	public void ApplicationProject_ShouldNotHaveDependencyOn_InfrastructureProject()
	{
		var result = Types.InAssembly(ApplicationAssembly)
			.Should()
			.NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
			.GetResult();

		result.IsSuccessful.Should().BeTrue();
	}

	[Fact]
	public void ApplicationProject_ShouldNotHaveDependencyOn_WebProject()
	{
		var result = Types.InAssembly(ApplicationAssembly)
			.Should()
			.NotHaveDependencyOn(WebAssembly.GetName().Name)
			.GetResult();

		result.IsSuccessful.Should().BeTrue();
	}
}
