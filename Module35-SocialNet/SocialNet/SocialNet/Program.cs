using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialNet;
using SocialNet.Data;
using SocialNet.Models.Users;
using SocialNet.Validation;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile("appsettings.Development.json")
    .Build();

var assembly = Assembly.GetAssembly(typeof(MappingProfile));
builder.Services.AddAutoMapper(assembly);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

string connection = config.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection), ServiceLifetime.Singleton)
    .AddIdentity<User, IdentityRole>(opts => {
        opts.Password.RequiredLength = 5;   
        opts.Password.RequireNonAlphanumeric = false;  
        opts.Password.RequireLowercase = false; 
        opts.Password.RequireUppercase = false; 
        opts.Password.RequireDigit = false;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();
// builder.Services.AddFluentValidationAutoValidation().AddValidatorsFromAssemblyContaining<RegisterViewModelValidation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();