using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarcraftApi.Infraestructure.Models;

namespace WarcraftApi.Infraestructure.Persistance.EntityConfigurations;

public class CharacterWeaponConfiguration : IEntityTypeConfiguration<CharacterWeaponDm>
{
    public void Configure(EntityTypeBuilder<CharacterWeaponDm> builder)
    {
        builder.ToTable("Characters_Weapons");

        builder.HasKey(cw => new { cw.CharacterId, cw.WeaponId });

        builder.HasOne(cw => cw.Character)
            .WithMany(c => c.CharacterWeapons)
            .HasForeignKey(cw => cw.CharacterId);

        builder.HasOne(cw => cw.Weapon)
            .WithMany(w => w.CharacterWeapons)
            .HasForeignKey(cw => cw.WeaponId);
    }
}
