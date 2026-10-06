using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PetSweet.Domain;

public record Pet
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid KindId { get; set; }
    public int CityId { get; set; }
    public DateTimeOffset Date { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public Kind? Kind { get; set; }
    public ICollection<Message>? Messages { get; init; } = new();
}

public record PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {

        builder.ToTable("Pets");

        builder
            .HasIndex(p => p.Date)
            .IsDescending();

        builder
            .Property(p => p.Id)
            .HasValueGenerator<AppGuidValueGenerator>();

        builder
            .Property(p => p.Name)
            .HasMaxLength(100);

        builder
            .HasMany(p => p.Messages)
            .WithOne(p => p.Pet)
            .HasForeignKey(p => p.PetId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

