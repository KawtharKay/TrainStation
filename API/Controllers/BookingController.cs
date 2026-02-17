using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Application.Commands.CreateBooking;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
