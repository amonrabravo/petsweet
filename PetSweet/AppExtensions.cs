using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetSweet.Domain;

namespace PetSweet;

public static class AppExtensions
{
    public static async Task<IApplicationBuilder> UsePetSweet(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

        await context.Database.MigrateAsync();

        var roles = new[]
        {
            new Role { Name = "Administrators", DisplayName = "Yöneticiler" },
            new Role { Name = "Members", DisplayName = "Üyeler" },
        }.ToList();

        foreach (var role in roles)
                await roleManager.CreateAsync(role);

        {

            var user = new User
            {
                UserName = configuration.GetValue<string>("DefaultUser:UserName"),
                Email = configuration.GetValue<string>("DefaultUser:Email"),
                GivenName = configuration.GetValue<string>("DefaultUser:GivenName")!,
            };
            await userManager.CreateAsync(user, configuration.GetValue<string>("DefaultUser:Password")!);
            await userManager.AddToRoleAsync(user, "Administrators");
        }

#if DEBUG
        {
            var user = new User
            {
                UserName = "testuser1@petsweet.com",
                Email = "testuser1@petsweet.com",
                GivenName = "Test User 1",
            };
            await userManager.CreateAsync(user, "1");
            await userManager.AddToRoleAsync(user, "Members");
        }
#endif

        return app;
    }
}
