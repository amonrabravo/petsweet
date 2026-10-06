using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PetSweet.Domain;

public class User : IdentityUser<Guid>
{
    public string GivenName { get; set; } = null!;

    public ICollection<Pet> Pets { get; set; } = [];
    public ICollection<Message> Messages { get; set; } = [];

}

public class UserConfiguration : IEntityTypeConfiguration<User>
{

    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.Property(p => p.Id).HasValueGenerator<AppGuidValueGenerator>();

        builder
           .HasMany(p => p.Pets)
           .WithOne(p => p.User)
           .HasForeignKey(p => p.UserId)
           .OnDelete(DeleteBehavior.Restrict);

        builder
           .HasMany(p => p.Messages)
           .WithOne(p => p.User)
           .HasForeignKey(p => p.UserId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}