using Application.Querries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Application.Commands.RegisterStation;
using static Application.Querries.GetStation;
using static Application.Querries.GetStations;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        public async Task<IActionResult> RegisterStation(RegisterStationCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStationById(Guid id)
        {
            var response = await _mediator.Send(new GetStationQuery(id));
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStations([FromQuery] GetStationsQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
