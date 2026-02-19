using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.Querries.GetSeats;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController(IMediator mediator) : ControllerBase
    {
        [HttpGet("{coachId}")]
        public async Task<IActionResult> GetAllSeats(Guid coachId)
        {
            var response = await mediator.Send(new GetSeatsQuery(coachId));
            return Ok(response);
        }
    }
}
