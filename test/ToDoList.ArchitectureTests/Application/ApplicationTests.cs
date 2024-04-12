using FluentAssertions;

using FluentValidation;

using NetArchTest.Rules;

using ToDoList.ArchitectureTests.Infrastructure;

namespace ToDoList.ArchitectureTests.Application;

public class ApplicationTests : BaseTest
{
	[Fact]
	public void Validators_ShouldHave_NameEndingWith_Validator()
	{
		TestResult result = Types.InAssembly(ApplicationAssembly)
			.That()
			.Inherit(typeof(AbstractValidator<>))
			.Should()
			.HaveNameEndingWith("Validator")
			.GetResult();

		result.IsSuccessful.Should().BeTrue();
	}

	[Fact]
	public void Validators_Should_NotBePublic()
	{
		TestResult result = Types.InAssembly(ApplicationAssembly)
			.That()
			.Inherit(typeof(AbstractValidator<>))
			.Should()
			.NotBePublic()
			.GetResult();

		result.IsSuccessful.Should().BeTrue();
	}
}
