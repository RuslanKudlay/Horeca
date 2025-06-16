using Application.Queries;
using Application.Queries.Supporting.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Horeca.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize(Policy = "TokenAuthorization")]
[Authorize]
public class BaseController<TQuery, TResult> : ControllerBase where TQuery : BaseQuery<TResult>
{
    private readonly IMediator _mediator;

    public BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() 

    {
        try
        {
            var data = await _mediator.Send(Activator.CreateInstance<TQuery>());
            return Ok(new ActionResultDto<TResult>()
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