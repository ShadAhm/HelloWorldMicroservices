using MediatR;
using Planets.Domain.Entities;
using Planets.Persistence;

namespace Planets.Application.Planets.Commands;

internal class InsertPlanetCommandHandler : IRequestHandler<InsertPlanetCommand, Guid>
{
    private readonly IDataFile<Planet> _context;

    public InsertPlanetCommandHandler(IDataFile<Planet> context)
    {
        _context = context;
    }

    public Task<Guid> Handle(InsertPlanetCommand request, CancellationToken cancellationToken)
    {
        throw new InvalidOperationException();
    }
}
