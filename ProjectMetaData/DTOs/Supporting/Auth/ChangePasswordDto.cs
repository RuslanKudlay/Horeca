namespace Horeca.DTOs.Supporting.Auth;

public class ChangePasswordDto
{
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
    public Guid UserId { get; set; }
}