using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PetSweet.Domain;

public class Role : IdentityRole<Guid>
{
    public string DisplayName { get; set; } = null!;


}

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{

    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");
        builder.Property(p => p.Id).HasValueGenerator<AppGuidValueGenerator>();

    }
}