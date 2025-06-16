using Application.Commands.Supporting.User;
using Application.Queries.Supporting.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Horeca.Controllers.Supporting.User;

public class UserController : BaseController
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
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
            var data = await _mediator.Send(new GetAllUsersQuery());
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
    
    [HttpPost("change-password")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ActionResultDto<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ActionResultDto<bool>),StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ActionResultDto<bool>),StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ActionResultDto<bool>),StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand request)
    {
        try
        {
            var result = await _mediator.Send(request);
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