using MediatR;

namespace Planets.Application.Planets.Queries;

public class GetPlanetQuery : IRequest<PlanetSingleEndonymDto>
{
    public string? Culture { get; set; }
    public string Name { get; set; } = string.Empty;
}

