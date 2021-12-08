using MediatR;
using Microsoft.EntityFrameworkCore;
using Planets.Domain.Entities;
using Planets.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets.Application.Planets.Queries;

public class GetPlanetsListQueryHandler : IRequestHandler<GetPlanetsListQuery, IEnumerable<PlanetDto>>
{
    private readonly IDataFile<Planet> _context;

    public GetPlanetsListQueryHandler(IDataFile<Planet> context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PlanetDto>> Handle(GetPlanetsListQuery request, CancellationToken cancellationToken)
    {
        var planets = _context.GetAll();
        return (planets).Select(p => new PlanetDto
        {
            Name = p.Name,
            Endonym = p.Endonyms.FirstOrDefault()?.Value
        });
    }
}

