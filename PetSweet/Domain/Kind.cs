using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PetSweet.Domain;

public record Kind
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<Pet>? Pets { get; init; } = new();
}

public record KindConfiguration : IEntityTypeConfiguration<Kind>
{
    public void Configure(EntityTypeBuilder<Kind> builder)
    {

        builder.ToTable("Kinds");
        builder.HasIndex(p => p.Name).IsUnique();

        builder
            .Property(p => p.Id)
            .HasValueGenerator<AppGuidValueGenerator>();

        builder
            .HasMany(p => p.Pets)
            .WithOne(p => p.Kind)
            .HasForeignKey(p => p.KindId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Property(p => p.Name)
            .HasMaxLength(100);

    }
}

