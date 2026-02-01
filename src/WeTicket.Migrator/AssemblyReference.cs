using System.Reflection;

namespace WeTicket.Migrator;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}