using System.Reflection;

namespace MiniStore.Blazor;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}