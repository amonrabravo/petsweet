using Microsoft.AspNetCore.Identity;

namespace PetSweet.Domain;

public record User : IdentityUser<Guid>
{
    public string GivenName { get; set; } = null!;
}

public record UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.Property(p => p.Id).HasValueGenerator<AppGuidValueGenerator>();
    }
}