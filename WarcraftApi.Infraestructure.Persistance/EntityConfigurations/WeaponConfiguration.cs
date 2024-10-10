using WarcraftApi.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WarcraftApi.Infraestructure.Persistance.EntityConfigurations;
public class WeaponConfiguration : IEntityTypeConfiguration<WeaponDm>
{
    public void Configure(EntityTypeBuilder<WeaponDm> builder)
    {
        builder.ToTable("Weapons");

        builder.HasKey(w => w.Id);

        builder.Property(w => w.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(w => w.Damage);
        builder.Property(w => w.Lore)
            .HasMaxLength(1000);

        builder.HasMany(w => w.CharacterWeapons)
            .WithOne(cw => cw.Weapon)
            .HasForeignKey(cw => cw.WeaponId);
    }
}
