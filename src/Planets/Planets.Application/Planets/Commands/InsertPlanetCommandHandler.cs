using MediatR;
using Planets.Domain.Entities;
using Planets.Persistence;

namespace Planets.Application.Planets.Commands;

internal class InsertPlanetCommandHandler : IRequestHandler<InsertPlanetCommand, Guid>
{
    private readonly Persistence.Io.IDataAccessor _context;

    public InsertPlanetCommandHandler(Persistence.Io.IDataAccessor context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(InsertPlanetCommand request, CancellationToken cancellationToken)
    {
        //var entity = new Planet(request.Name, request.IsDwarf, request.Endonym);
        //await _context.Planets.AddAsync(entity);
        //await _context.SaveChangesAsync(cancellationToken);
        //return entity.Id;

        return await Task.FromResult(Guid.NewGuid());
    }
}
