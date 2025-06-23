namespace Horeca.DTOs.Supporting.User;

public record ChangePasswordDto
{
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
    public Guid UserId { get; set; }
}