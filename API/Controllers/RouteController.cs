using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Application.Commands.CreateRoute;
using static Application.Querries.GetAllRoutes;
using static Application.Querries.GetRoute;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateRoute(CreateRouteCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRouteById(Guid id)
        {
            var response = await mediator.Send(new GetRouteQuery(id));
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoutes([FromQuery] GetAllRoutesQuery query)
        {
            var response = await mediator.Send(query);
            return Ok(response);
        }
    }
}
