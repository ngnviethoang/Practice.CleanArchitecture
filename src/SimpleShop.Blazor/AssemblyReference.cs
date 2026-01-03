using System.Reflection;

namespace SimpleShop.Blazor;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}