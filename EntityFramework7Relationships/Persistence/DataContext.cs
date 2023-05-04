using EntityFramework7Relationships.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework7Relationships.Persistence;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Character> Characters { get; set; }
    public DbSet<BackPack> BackPacks { get; set; }
    public DbSet<Weapon> Weapons { get; set; }
    public DbSet<Faction> FactionsWeapons { get; set; }
}