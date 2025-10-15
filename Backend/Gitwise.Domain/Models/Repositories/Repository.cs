namespace Gitwise.Domain.Models.Repositories;

public record Repository(
    string Name,
    string FullName,
    string Link,
    bool Private,
    string Description);