using MediatR;
using Microsoft.AspNetCore.Mvc;
using Planets.Application.Planets.Commands;
using Planets.Application.Planets.Queries;

namespace Planets.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private readonly ILogger<PlanetController> _logger;
        private readonly IMediator _mediator;

        public PlanetController(ILogger<PlanetController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<Guid> Post(InsertPlanetCommand command)
        {
            _logger.Log(LogLevel.Information, $"Creating planet {command.Name}");
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<IEnumerable<PlanetDto>> Get()
        {
            return await _mediator.Send(new GetPlanetsListQuery());
        }
    }
}
