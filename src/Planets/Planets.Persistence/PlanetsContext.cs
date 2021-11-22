using Microsoft.EntityFrameworkCore;
using Planets.Domain.Entities;

namespace Planets.Persistence;

public class PlanetsContext : DbContext, IPlanetsContext
{
    public DbSet<Planet> Planets { get; set; }
    public PlanetsContext(DbContextOptions<PlanetsContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Planet>().ToTable("planets");

        base.OnModelCreating(modelBuilder);
    }
}
