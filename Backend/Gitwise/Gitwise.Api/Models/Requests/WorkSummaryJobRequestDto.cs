namespace Gitwise.Api.Models.Requests;

public record WorkSummaryJobRequestDto(Guid TenantId, Guid DeveloperId, DateOnly SummaryDate);
