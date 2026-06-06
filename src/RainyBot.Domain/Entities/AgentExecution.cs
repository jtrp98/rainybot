using RainyBot.Domain.Common;

namespace RainyBot.Domain.Entities;

public sealed class AgentExecution : AuditableEntity
{
    public string AgentName { get; set; } = string.Empty;
    public string Event { get; set; } = string.Empty;
    public string? Details { get; set; }
}
