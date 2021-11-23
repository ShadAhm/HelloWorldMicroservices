using MediatR;
using Microsoft.EntityFrameworkCore;
using Planets.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets.Application.Planets.Queries;

public class GetPlanetsListQueryHandler : IRequestHandler<GetPlanetsListQuery, IEnumerable<PlanetDto>>
{
    private readonly IPlanetsContext _context;

    public GetPlanetsListQueryHandler(IPlanetsContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PlanetDto>> Handle(GetPlanetsListQuery request, CancellationToken cancellationToken)
    {
        var planets = await _context.Planets.ToListAsync(cancellationToken);
        return (planets).Select(p => new PlanetDto { 
            Name = p.Name,
            Endonym = p.Endonym?.Name
        });
    }
}

