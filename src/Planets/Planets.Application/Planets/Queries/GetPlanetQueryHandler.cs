using MediatR;
using Planets.Domain.Entities;
using Planets.Persistence;

namespace Planets.Application.Planets.Queries;

public class GetPlanetQueryHandler : IRequestHandler<GetPlanetQuery, PlanetSingleEndonymDto?>
{
    private readonly IDataFile<Planet> _context;

    public GetPlanetQueryHandler(IDataFile<Planet> context)
    {
        _context = context;
    }

    public Task<PlanetSingleEndonymDto?> Handle(GetPlanetQuery request, CancellationToken cancellationToken)
    {
        var planet = _context.GetAll()
            .FirstOrDefault(o => o.Name == request.Name);

        if(planet is not null)
        {
            var dto = new PlanetSingleEndonymDto
            {
                Name = planet.Name,
                Endonym = planet.Endonyms
                    .FirstOrDefault(o => string.IsNullOrWhiteSpace(request.Culture) && o.Culture == null || o.Culture == request.Culture)
                    ?.Value
            };

            return Task.FromResult<PlanetSingleEndonymDto?>(dto);
        }

        return Task.FromResult(default(PlanetSingleEndonymDto?));
    }
}

