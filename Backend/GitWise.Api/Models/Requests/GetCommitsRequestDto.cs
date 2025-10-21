namespace GitWise.Api.Models.Requests;

public record GetCommitsRequestDto(
    string OrganisationName,
    string AuthorEmail,
    DateTime Date);