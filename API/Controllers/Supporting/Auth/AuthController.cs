using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Supporting.Auth.Interfaces;
using Horeca.Constants;
using Horeca.DTOs.Supporting.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Horeca.Controllers.Supporting.Auth;
public class AuthController : BaseController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ActionResultDto<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ActionResultDto<bool>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ActionResultDto<bool>), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ActionResultDto<bool>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        try
        {
            var token = await _authService.GetTokenAsync(loginDto);
            return Ok(new { token = token });
        }
        catch (Exception e)
        {
            return BadRequest(new ActionResultDto<bool>()
            {
                Message = e.Message
            });
        }
    }

    [HttpPost("register")]
    [AllowAnonymous]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ActionResultDto<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ActionResultDto<bool>),StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ActionResultDto<bool>),StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ActionResultDto<bool>),StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RegisterUser([FromBody] CreateUserRequestDto request)
    {
        try
        {
            var result = await _authService.CreateUserAsync(request);
            return Ok(new ActionResultDto<bool>()
            {
                Data = result
            });
        }
        catch (Exception e)
        {
            return BadRequest(new ActionResultDto<bool>()
            {
                Message = e.Message
            });
        }
    }

    [HttpPost("change-password")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ActionResultDto<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ActionResultDto<bool>),StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ActionResultDto<bool>),StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ActionResultDto<bool>),StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto request)
    {
        try
        {
            var result = await _authService.ChangePasswordAsync(request);
            return Ok(new ActionResultDto<bool>()
            {
                Data = result
            });
        }
        catch (Exception e)
        {
            return BadRequest(new ActionResultDto<bool>()
            {
                Message = e.Message
            });
        }
    }
    
}