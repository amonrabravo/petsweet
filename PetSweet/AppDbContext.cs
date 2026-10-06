using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetSweet.Domain;

namespace PetSweet;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<
    User, 
    Role, 
    Guid,    
    IdentityUserClaim<Guid>,
    IdentityUserRole<Guid>, 
    IdentityUserLogin<Guid>, 
    IdentityRoleClaim<Guid>, 
    IdentityUserToken<Guid>>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public DbSet<City> Cities => Set<City>();
    public DbSet<Kind> Kinds => Set<Kind>();
    public DbSet<Message> Messages => Set<Message>();
    public DbSet<Pet> Pets => Set<Pet>();
    public DbSet<PetImage> PetImages => Set<PetImage>();
}
