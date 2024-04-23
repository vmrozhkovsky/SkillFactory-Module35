using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialNet.Data.Models;

namespace SocialNet.Data;

public class ApplicationDbContext: IdentityDbContext < User > 
{
    public ApplicationDbContext(DbContextOptions < ApplicationDbContext > options): base(options) 
    {
        Database.EnsureCreated();
    }
}