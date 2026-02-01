using System.Reflection;
using NetArchTest.Rules;
using WeTicket.Application.Shared.Commands;
using WeTicket.Application.Shared.Queries;

namespace WeTicket.ArchitectureTests;

public class CqrsRuleConventionTests
{
    [Fact]
    public void CommandAndQueryHandlerShouldHaveBeSealed()
    {
        // Arrange
        Assembly assembly = Application.AssemblyReference.Assembly;

        // Act
        TestResult? testResult = Types.InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(ICommandHandler<,>))
            .Or()
            .ImplementInterface(typeof(IQueryHandler<,>))
            .Should()
            .BeSealed()
            .GetResult();

        // Assert
        Assert.True(testResult.IsSuccessful);
    }

    #region Command

    [Fact]
    public void CommandShouldHaveNamingConventionEndingCommand()
    {
        // Arrange
        Assembly assembly = Application.AssemblyReference.Assembly;

        // Act
        TestResult? testResult = Types.InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(ICommand<>))
            .Should()
            .HaveNameEndingWith("Command")
            .GetResult();

        // Assert
        Assert.True(testResult.IsSuccessful);
    }

    [Fact]
    public void CommandHandlerShouldHaveNamingConventionEndingCommandHandler()
    {
        // Arrange
        Assembly assembly = Application.AssemblyReference.Assembly;

        // Act
        TestResult? testResult = Types.InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(ICommandHandler<,>))
            .Should()
            .HaveNameEndingWith("CommandHandler")
            .GetResult();

        // Assert
        Assert.True(testResult.IsSuccessful);
    }

    #endregion

    #region Query

    [Fact]
    public void QueryShouldHaveNamingConventionEndingQuery()
    {
        // Arrange
        Assembly assembly = Application.AssemblyReference.Assembly;

        // Act
        TestResult? testResult = Types.InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(IQuery<>))
            .Should()
            .HaveNameEndingWith("Query")
            .GetResult();

        // Assert
        Assert.True(testResult.IsSuccessful);
    }

    [Fact]
    public void QueryHandlerShouldHaveNamingConventionEndingQueryHandler()
    {
        // Arrange
        Assembly assembly = Application.AssemblyReference.Assembly;

        // Act
        TestResult? testResult = Types.InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(IQueryHandler<,>))
            .Should()
            .HaveNameEndingWith("QueryHandler")
            .GetResult();

        // Assert
        Assert.True(testResult.IsSuccessful);
    }

    #endregion
}