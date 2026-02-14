namespace SummaryEngine.Domain.Models.WorkSummary;

public record Repository(
    string Name,
    string FullName,
    string Link,
    bool Private,
    string Description);