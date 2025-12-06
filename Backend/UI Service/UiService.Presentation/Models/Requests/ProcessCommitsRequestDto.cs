namespace UiService.Models.Requests;

public record ProcessCommitsRequestDto(
    string? OrganisationName,
    string AuthorUsername,
    DateTime Date);