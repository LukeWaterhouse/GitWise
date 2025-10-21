namespace GitWise.Api.Models.Repository;

public record RepositoryDto(
    string Name,
    string FullName,
    string Link,
    bool Private,
    string Description);