using Application.Services.Supporting.User.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Horeca.Controllers.Supporting.User;

public class UserController : BaseController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ActionResultDto<IReadOnlyList<Domain.Supporting.Auth.Entities.User>>),
        StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ActionResultDto<IReadOnlyList<Domain.Supporting.Auth.Entities.User>>),
        StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ActionResultDto<IReadOnlyList<Domain.Supporting.Auth.Entities.User>>),
        StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ActionResultDto<IReadOnlyList<Domain.Supporting.Auth.Entities.User>>),
        StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var data = await _userService.GetAllAsync();
            return Ok(new ActionResultDto<IReadOnlyList<Domain.Supporting.Auth.Entities.User>>()
            {
                Data = data
            });
        }
        catch (Exception e)
        {
            return BadRequest(new ActionResultDto<IReadOnlyList<Domain.Supporting.Auth.Entities.User>>()
            {
                Message = e.Message
            });
        }
    }
}