using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Application.Commands.RegisterTrain;
using static Application.Querries.GetAllTrains;
using static Application.Querries.GetTrain;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TrainController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> RegisterTrian(RegisterTrainCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainByTrainNo(Guid id)
        {
            var result = await _mediator.Send(new GetTrainQuery(id));
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTrains([FromQuery] GetAllTrainsQuery command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
