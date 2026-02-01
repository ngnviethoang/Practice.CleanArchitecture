using System.Reflection;

namespace WeTicket.Blazor;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}