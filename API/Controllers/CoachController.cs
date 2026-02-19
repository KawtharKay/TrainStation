using Application.Contracts.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Application.Commands.CreateCoach;
using static Application.Querries.GetCoach;
using static Application.Querries.GetCoaches;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public CoachController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = AppRoles.SuperAdmin)]
        [HttpPost]
        public async Task<IActionResult> CreateCoach(CreateCoachCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoachById(Guid id)
        {
            var response = await _mediator.Send(new GetCoachQuery(id));
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoaches([FromQuery] GetAllCoachesQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
