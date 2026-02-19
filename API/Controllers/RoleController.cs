using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.Commands.CreateRole;
using static Application.Commands.CreateRoles;
using static Application.Querries.GetRoles;

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
        [HttpPost("roles")]
        public async Task<IActionResult> CreateRoles(CreateRolesCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles([FromQuery] GetAllRolesQuery query)
        {
            var response = await mediator.Send(query);
            return Ok(response);
        }
    }
}
