using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Application.Commands.CreateRole;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
