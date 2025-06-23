namespace Horeca.DTOs.Supporting.Auth;

public record CreateUserRequestDto
{
    public string? Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? Phone { get; set; }
}