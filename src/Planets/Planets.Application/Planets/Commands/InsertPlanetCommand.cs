using MediatR;

namespace Planets.Application.Planets.Commands;

public class InsertPlanetCommand : IRequest<Guid>
{
    public string Name { get; set; }
}
