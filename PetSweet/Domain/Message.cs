using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PetSweet.Domain;

public record Message
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid PetId { get; set; }
    public DateTimeOffset Date { get; set; }
    public string Content { get; set; } = null!;

    public User? User { get; set; }
    public Pet? Pet { get; set; }
}

public record MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {

        builder.ToTable("Messages");

        builder
            .HasIndex(p => p.Date);
            
        builder
            .Property(p => p.Id)
            .HasValueGenerator<AppGuidValueGenerator>();
    }
}

