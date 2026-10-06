using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PetSweet.Domain;

public record City
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Pet> Pets { get; init; } = [];
}

public record CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities");

        builder.HasIndex(p => p.Name).IsUnique();

        builder
            .Property(p => p.Name)
            .HasMaxLength(100);

        builder
            .HasMany(p => p.Pets)
            .WithOne(p => p.City)
            .HasForeignKey(p => p.CityId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

