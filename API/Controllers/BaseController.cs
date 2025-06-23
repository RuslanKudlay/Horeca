using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Horeca.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize(Policy = "TokenAuthorization")]
[Authorize]
public class BaseController : ControllerBase
{
    
}