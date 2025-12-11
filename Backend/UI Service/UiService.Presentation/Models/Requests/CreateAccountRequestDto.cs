namespace UiService.Models.Requests;

public record CreateAccountRequestDto(
    string Email,
    RoleDto Role);