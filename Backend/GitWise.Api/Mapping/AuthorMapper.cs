using GitWise.Api.Models.Commit;
using Gitwise.Domain.Models;

namespace GitWise.Api.Mapping;

public static class AuthorMapper
{
    public static AuthorDto FromDomain(this Author author)
    {
        return new AuthorDto(
            author.Name,
            author.Email);
    }
    
    public static Author ToDomain(this AuthorDto authorDto)
    {
        return new Author(
            authorDto.Name,
            authorDto.Email);
    }
}