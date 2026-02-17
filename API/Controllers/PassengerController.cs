using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Application.Commands.RegisterPassenger;
using static Application.Querries.GetPassenger;
using static Application.Querries.GetPassengers;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PassengerController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> RegisterPassenger(RegisterPassengerCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPassengerById(Guid id)
        {
            var response = await mediator.Send(new GetPassengerQuery(id));
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPassengers([FromQuery] GetAllPassengersQuery query)
        {
            var response = await mediator.Send(query);
            return Ok(response);
        }
    }
}
