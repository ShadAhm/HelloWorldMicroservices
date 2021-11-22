using Microsoft.EntityFrameworkCore;
using Planets.Domain.Entities;

namespace Planets.Persistence;

public interface IPlanetsContext
{
    DbSet<Planet> Planets { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    int SaveChanges();
}
