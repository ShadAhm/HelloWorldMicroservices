using MediatR;

namespace Planets.Application.Planets.Queries;

public class GetPlanetsListQuery : IRequest<IEnumerable<PlanetDto>>
{
}
