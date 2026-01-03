using System.Reflection;

namespace SimpleShop.Migrator;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}