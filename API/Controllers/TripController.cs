using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Application.Commands.AssignSeat;
using static Application.Commands.CreateTrip;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateTrip(CreateTripCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignSeat(AssignSeatCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
