using Planets.Domain.Entities;

namespace Planets.Persistence;

public class DataContext : IDataContext
{
    public DataFile<Planet>? Planets { get; private set; }

    public DataContext()
    {
        InitalizeAll();
    }

    private void InitalizeAll()
    {
        // initialize all data files
    }
}
