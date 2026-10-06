using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PetSweet.Domain;

public record PetImage
{
    public Guid Id { get; set; }
    public Guid PetId { get; set; }
}

public record PetImageConfiguration : IEntityTypeConfiguration<PetImage>
{
    public void Configure(EntityTypeBuilder<PetImage> builder)
    {
        builder.ToTable("PetImages");
    }
}

