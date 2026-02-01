namespace WeTicket.Application.Shared.Decorators.AuditLogs;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
public sealed class AuditLogAttribute : Attribute;