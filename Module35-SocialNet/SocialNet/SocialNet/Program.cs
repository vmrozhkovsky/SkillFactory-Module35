using System.Reflection;
using AutoMapper;
using SocialNet.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialNet;
using SocialNet.Data;
using SocialNet.Data.Repository;
using SocialNet.Data.UoW;
using SocialNet.Extentions;
using SocialNet.Models.Users;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile("appsettings.Development.json")
    .Build();

// var assembly = Assembly.GetAssembly(typeof(MappingProfile));
// builder.Services.AddAutoMapper(assembly);

builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

string connection = config.GetConnectionString("DefaultConnection");
// builder.Services.AddSqlServer<ApplicationDbContext>(config.GetConnectionString("DefaultConnection"));
// //.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection), ServiceLifetime.Singleton)
// builder.Services
//     .AddTransient<IUnitOfWork, UnitOfWork>()
//     .AddCustomRepository<Message, MessageRepository>()
//     .AddCustomRepository<Friend, FriendsRepository>();

builder.Services
    .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection))
    .AddCustomRepository<Friend, FriendsRepository>()
    .AddCustomRepository<Message, MessageRepository>()
    .AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddIdentity<User, IdentityRole>(opts => {
        opts.Password.RequiredLength = 5;   
        opts.Password.RequireNonAlphanumeric = false;  
        opts.Password.RequireLowercase = false; 
        opts.Password.RequireUppercase = false; 
        opts.Password.RequireDigit = false;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();
// builder.Services.AddFluentValidationAutoValidation().AddValidatorsFromAssemblyContaining<RegisterViewModelValidation>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

}
else
{
    app.UseDeveloperExceptionPage();
}
app.UseHttpsRedirection();
var cachePeriod = "0";
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age={cachePeriod}");
    }
});

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Register",
    pattern: "{controller=Register}/{action=Register}/{id?}");
app.MapControllerRoute(
    name: "AccountManager",
    pattern: "{controller=AccountManager}/{action=Login}/{id?}");

app.MapRazorPages();

app.Run();