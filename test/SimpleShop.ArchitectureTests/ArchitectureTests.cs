using System.Reflection;
using NetArchTest.Rules;

namespace SimpleShop.ArchitectureTests;

public class ArchitectureTests
{
    private const string _applicationNamespace = "SimpleShop.Application";
    private const string _contractNamespace = "SimpleShop.Contract";
    private const string _domainNamespace = "SimpleShop.Domain";
    private const string _infrastructureNamespace = "SimpleShop.Infrastructure";
    private const string _persistenceNamespace = "SimpleShop.Persistence";
    private const string _appHostNamespace = "SimpleShop.AppHost";
    private const string _blazorNamespace = "SimpleShop.Blazor";
    private const string _migratorNamespace = "SimpleShop.Migrator";
    private const string _webApiNamespace = "SimpleShop.WebAPI";

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