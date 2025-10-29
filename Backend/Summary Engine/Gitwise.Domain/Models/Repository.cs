namespace Gitwise.Domain.Models;

public record Repository(
    string Name,
    string FullName,
    string Link,
    bool Private,
    string Description);