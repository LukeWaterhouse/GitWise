namespace Gitwise.Api.Models.Requests;

public record GetCommitsRequestDto(
    string? OrganisationName,
    string AuthorUsername,
    DateTime Date);