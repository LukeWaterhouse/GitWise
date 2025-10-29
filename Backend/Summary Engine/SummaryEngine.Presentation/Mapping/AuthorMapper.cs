using SummaryEngine.Domain.Models;
using SummaryEngine.Presentation.Models.Commit;

namespace SummaryEngine.Presentation.Mapping;

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