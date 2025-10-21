namespace GitWise.Api.Models;

public record RepositoryDto(
    string Name,
    string FullName,
    string Link,
    bool Private,
    string Description);