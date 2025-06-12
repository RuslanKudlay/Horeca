using Microsoft.AspNetCore.Authorization;

namespace Horeca.DTOs.Supporting.Auth;

public class TokenRequirement : IAuthorizationRequirement
{
    public TokenRequirement() { }
}