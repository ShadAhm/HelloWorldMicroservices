using MediatR;
using Planets.Domain.Entities;
using Planets.Persistence;

namespace Planets.Application.Planets.Commands;

internal class InsertPlanetCommandHandler : IRequestHandler<InsertPlanetCommand, int>
{
    private readonly IPlanetsContext _context;

    public InsertPlanetCommandHandler(IPlanetsContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(InsertPlanetCommand request, CancellationToken cancellationToken)
    {
        var o = await _context.Planets.AddAsync(new Planet(request.Name));
        await _context.SaveChangesAsync(cancellationToken);
        return 0;
    }
}
