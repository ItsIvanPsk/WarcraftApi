    using Microsoft.EntityFrameworkCore;
    using WarcraftApi.Infraestructure.Models;

    namespace WarcraftApi.Infraestructure.Persistance
    {
        public class ApplicationDbContext : DbContext
        {
            public DbSet<CharacterDm> CharacterDm { get; set; }

            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<CharacterDm>().ToTable("Characters");
                modelBuilder.Entity<CharacterDm>()
                    .HasKey(a => a.Id);

                modelBuilder.Entity<CharacterDm>()
                    .Property(b => b.Name)
                    .HasMaxLength(100)
                    .IsRequired();
                
                modelBuilder.Entity<CharacterDm>()
                    .Property(b => b.Lore)
                    .HasMaxLength(100)
                    .IsRequired();

                modelBuilder.Entity<CharacterDm>()
                    .Property(b => b.Life);
                
                modelBuilder.Entity<CharacterDm>()
                    .Property(b => b.Damage);
                
                modelBuilder.Entity<CharacterDm>()
                    .Property(b => b.Speed);
            }
        }
    }