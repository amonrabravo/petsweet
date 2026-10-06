using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetSweet;
using PetSweet.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<User, IdentityRole<Guid>>(options =>
{
    builder.Configuration.GetSection("IdentityOptions").Bind(options);
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();


var app = builder.Build();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
