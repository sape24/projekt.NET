using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using projekt.NET.Models;

namespace projekt.NET.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {      
    }

    public DbSet<Recept> Recept { get; set; }
    public DbSet<Kategori> Kategori { get; set; }
    public DbSet<Ingrediens> Ingrediens { get; set; }
}