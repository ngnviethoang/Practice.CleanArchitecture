using System.Reflection;
using MiniStore.Contract;
using NetArchTest.Rules;

namespace MiniStore.ArchitectureTests;

public class ArchitectureTests
{
    private const string _applicationNamespace = "MiniStore.Application";
    private const string _contractNamespace = "MiniStore.Contract";
    private const string _domainNamespace = "MiniStore.Domain";
    private const string _infrastructureNamespace = "MiniStore.Infrastructure";
    private const string _persistenceNamespace = "MiniStore.Persistence";
    private const string _appHostNamespace = "MiniStore.AppHost";
    private const string _blazorNamespace = "MiniStore.Blazor";
    private const string _migratorNamespace = "MiniStore.Migrator";
    private const string _webApiNamespace = "MiniStore.WebAPI";

    [Fact]
    public void ContractShouldNotHaveDependencyOnOtherProject()
    {
        // Arrange
        Assembly assembly = AssemblyReference.Assembly;
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