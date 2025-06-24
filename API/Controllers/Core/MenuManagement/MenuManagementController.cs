using Application.Commands.Core.MenuManagement;
using Horeca.DTOs.Core.MenuManagement;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Horeca.Controllers.Core.MenuManagement;

public class MenuManagementController : BaseController
{
    private readonly IMediator _mediator;

    public MenuManagementController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("create-menu")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ActionResultDto<bool>),
        StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ActionResultDto<bool>),
        StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ActionResultDto<bool>),
        StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ActionResultDto<bool>),
        StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateMenu(CreateMenuDto dto)
    {
        try
        {
            var createMenuCommand = new CreateMenuCommand(dto);
            var data = await _mediator.Send(createMenuCommand);
            return Ok(new ActionResultDto<bool>()
            {
                Data = data
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
    
    [HttpPost]
    [Route("create-menugroup")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ActionResultDto<bool>),
        StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ActionResultDto<bool>),
        StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ActionResultDto<bool>),
        StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ActionResultDto<bool>),
        StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateMenuGroup(List<CreateMenuGroupDto> dtoList)
    {
        try
        {
            var createMenuCommand = new CreateMenuGroupCommand(dtoList);
            var data = await _mediator.Send(createMenuCommand);
            return Ok(new ActionResultDto<bool>()
            {
                Data = data
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
    
    [HttpPost]
    [Route("update-menugroup")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ActionResultDto<bool>),
        StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ActionResultDto<bool>),
        StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ActionResultDto<bool>),
        StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ActionResultDto<bool>),
        StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateMenuGroup(List<UpdateMenuGroupDto> dtoList)
    {
        try
        {
            var updateMenuCommand = new UpdateMenuGroupCommand(dtoList);
            var data = await _mediator.Send(updateMenuCommand);
            return Ok(new ActionResultDto<bool>()
            {
                Data = data
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