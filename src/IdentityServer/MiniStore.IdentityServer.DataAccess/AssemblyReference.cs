using System.Reflection;

namespace MiniStore.IdentityServer.DataAccess;

internal static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}