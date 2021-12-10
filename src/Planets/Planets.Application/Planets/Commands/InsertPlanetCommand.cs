using MediatR;

namespace Planets.Application.Planets.Commands;

public class InsertPlanetCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string Endonym { get; set; } = string.Empty;
    public bool IsDwarf { get; set; }
}
