namespace Planets.Application.Planets.Queries;

public class PlanetDto
{
    public string Name { get; set; } = string.Empty;
    public IEnumerable<EndonymDto> Endonyms { get; set; } = new List<EndonymDto>();
}