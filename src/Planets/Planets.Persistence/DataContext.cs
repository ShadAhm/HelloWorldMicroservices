using Planets.Domain.Entities;

namespace Planets.Persistence;

public class DataContext : IDataContext
{
    public DataFile<Planet>? Planets { get; private set; }
}
