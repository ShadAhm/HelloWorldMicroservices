using MediatR;
using Planets.Domain.Entities;
using Planets.Persistence;

namespace Planets.Application.Planets.Commands;

internal class InsertPlanetCommandHandler : IRequestHandler<InsertPlanetCommand, Guid>
{
    private readonly IPlanetsContext _context;

    public InsertPlanetCommandHandler(IPlanetsContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(InsertPlanetCommand request, CancellationToken cancellationToken)
    {
        var entity = new Planet(request.Name, request.IsDwarf, request.Endonym);
        await _context.Planets.AddAsync(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}
