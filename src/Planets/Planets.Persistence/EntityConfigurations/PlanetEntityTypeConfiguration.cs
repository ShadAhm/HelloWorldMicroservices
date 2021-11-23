using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planets.Domain.Entities;
using Planets.Domain.ValueObjects;

namespace Planets.Persistence.EntityConfigurations;

internal class PlanetEntityTypeConfiguration : IEntityTypeConfiguration<Planet>
{
    public void Configure(EntityTypeBuilder<Planet> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.OwnsOne(o => o.Endonym);
    }
}
