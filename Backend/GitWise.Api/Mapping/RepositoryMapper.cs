using GitWise.Api.Models;
using Gitwise.Domain.Models.Repositories;

namespace GitWise.Api.Mapping;

public static class RepositoryMapper
{
    public static RepositoryDto FromDomain(this Repository repository)
    {
        return new RepositoryDto(
            repository.Name,
            repository.FullName,
            repository.Link,
            repository.Private,
            repository.Description);
    }
    
    public static Repository ToDomain(this RepositoryDto repositoryDto)
    {
        return new Repository(
            repositoryDto.Name,
            repositoryDto.FullName,
            repositoryDto.Link,
            repositoryDto.Private,
            repositoryDto.Description);
    }
}