using System.Reflection;
using NetArchTest.Rules;

namespace WeTicket.ArchitectureTests;

public class ArchitectureTests
{
    private const string _applicationNamespace = "WeTicket.Application";
    private const string _contractNamespace = "WeTicket.Contract";
    private const string _domainNamespace = "WeTicket.Domain";
    private const string _infrastructureNamespace = "WeTicket.Infrastructure";
    private const string _persistenceNamespace = "WeTicket.Persistence";
    private const string _appHostNamespace = "WeTicket.AppHost";
    private const string _blazorNamespace = "WeTicket.Blazor";
    private const string _migratorNamespace = "WeTicket.Migrator";
    private const string _webApiNamespace = "WeTicket.WebAPI";

    [Fact]
    public void ContractShouldNotHaveDependencyOnOtherProject()
    {
        // Arrange
        Assembly assembly = Contract.AssemblyReference.Assembly;
        string[] otherProjects =
        [
            _applicationNamespace,
            _domainNamespace,
            _infrastructureNamespace,
            _persistenceNamespace,
            _appHostNamespace,
            _blazorNamespace,
            _migratorNamespace,
            _webApiNamespace
        ];

        // Act
        TestResult? testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        Assert.True(testResult.IsSuccessful);
    }

    [Fact]
    public void DomainShouldNotHaveDependencyOnOtherProject()
    {
        // Arrange
        Assembly assembly = Domain.AssemblyReference.Assembly;
        string[] otherProjects =
        [
            _applicationNamespace,
            _infrastructureNamespace,
            _persistenceNamespace,
            _appHostNamespace,
            _blazorNamespace,
            _migratorNamespace,
            _webApiNamespace
        ];

        // Act
        TestResult? testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        Assert.True(testResult.IsSuccessful);
    }

    [Fact]
    public void ApplicationShouldNotHaveDependencyOnOtherProject()
    {
        // Arrange
        Assembly assembly = Application.AssemblyReference.Assembly;
        string[] otherProjects =
        [
            _infrastructureNamespace,
            _persistenceNamespace,
            _appHostNamespace,
            _blazorNamespace,
            _migratorNamespace,
            _webApiNamespace
        ];

        // Act
        TestResult? testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        Assert.True(testResult.IsSuccessful);
    }

    [Fact]
    public void InfrastructureShouldNotHaveDependencyOnOtherProject()
    {
        // Arrange
        Assembly assembly = Infrastructure.AssemblyReference.Assembly;
        string[] otherProjects =
        [
            _persistenceNamespace,
            _appHostNamespace,
            _blazorNamespace,
            _migratorNamespace,
            _webApiNamespace
        ];

        // Act
        TestResult? testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        Assert.True(testResult.IsSuccessful);
    }
}