namespace Gitwise.Api.Models.Requests;

public class WorkSummaryJobRequestDto
{
    public Guid TenantId { get; set; }
    public Guid DeveloperId { get; set; }
    public DateOnly SummaryDate { get; set; }
}
