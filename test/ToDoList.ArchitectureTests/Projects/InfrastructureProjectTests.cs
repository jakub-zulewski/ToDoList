using FluentAssertions;

using NetArchTest.Rules;

using ToDoList.ArchitectureTests.Infrastructure;

namespace ToDoList.ArchitectureTests.Projects;

public class InfrastructureProjectTests : BaseTest
{
	[Fact]
	public void InfrastructureProject_ShouldNotHaveDependencyOn_WebProject()
	{
		var result = Types.InAssembly(InfrastructureAssembly)
			.Should()
			.NotHaveDependencyOn(WebAssembly.GetName().Name)
			.GetResult();

		result.IsSuccessful.Should().BeTrue();
	}
}
