using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.Commands.AssignRole;
using static Application.Commands.CreateUser;
using static Application.Commands.LoginUser;
using static Application.Querries.GetUsers;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginUserCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignRole(AssignRoleCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUserQuery query)
        {
            var response = await mediator.Send(query);
            return Ok(response);
        }
    }
}
