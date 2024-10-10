using Microsoft.EntityFrameworkCore;
using WarcraftApi.Infraestructure.Models;
using WarcraftApi.Infraestructure.Persistance.EntityConfigurations;

public class ApplicationDbContext : DbContext
{
    public DbSet<CharacterDm> Characters { get; set; }
    public DbSet<WeaponDm> Weapons { get; set; }
    public DbSet<CharacterWeaponDm> CharacterWeapons { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CharacterWeaponConfiguration());
        modelBuilder.ApplyConfiguration(new CharacterConfiguration());
        modelBuilder.ApplyConfiguration(new WeaponConfiguration());
    }
}