namespace ApiService.Models;

public record ProcessCommitsRequestDto(
    string? OrganisationName,
    string AuthorUsername,
    DateTime Date);