using FluentAssertions;

using NetArchTest.Rules;

using ToDoList.ArchitectureTests.Infrastructure;

namespace ToDoList.ArchitectureTests.Projects;

public class DomainProjectTests : BaseTest
{
	[Fact]
	public void DomainProject_ShouldNotHaveDependencyOn_ApplicationProject()
	{
		var result = Types.InAssembly(DomainAssembly)
			.Should()
			.NotHaveDependencyOn(ApplicationAssembly.GetName().Name)
			.GetResult();

		result.IsSuccessful.Should().BeTrue();
	}

	[Fact]
	public void DomainProject_ShouldNotHaveDependencyOn_InfrastructureProject()
	{
		var result = Types.InAssembly(DomainAssembly)
			.Should()
			.NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
			.GetResult();

		result.IsSuccessful.Should().BeTrue();
	}

	[Fact]
	public void DomainProject_ShouldNotHaveDependencyOn_WebProject()
	{
		var result = Types.InAssembly(DomainAssembly)
			.Should()
			.NotHaveDependencyOn(WebAssembly.GetName().Name)
			.GetResult();

		result.IsSuccessful.Should().BeTrue();
	}
}
