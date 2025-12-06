namespace ApiService.Models;

public record ProcessCommitsRequestDto(
    string TenantId,
    string? OrganisationName,
    string AuthorUsername,
    DateTime Date);