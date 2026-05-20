using System.Reflection;

namespace MiniStore.Migrator;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}