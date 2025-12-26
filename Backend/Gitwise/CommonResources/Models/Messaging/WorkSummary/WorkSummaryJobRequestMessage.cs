namespace CommonResources.Models.Messaging.WorkSummary;

public record WorkSummaryJobRequestMessage(
    Guid JobId,
    Guid TenantId,
    Guid DeveloperId,
    DateOnly SummaryDate) : MessageBase(MessageType.WorkSummaryJob);