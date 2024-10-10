using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarcraftApi.Infraestructure.Models;

namespace WarcraftApi.Infraestructure.Persistance.EntityConfigurations;

public class CharacterConfiguration : IEntityTypeConfiguration<CharacterDm>
{
    public void Configure(EntityTypeBuilder<CharacterDm> builder)
    {
        builder.ToTable("Characters");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Lore)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Life);
        builder.Property(c => c.Damage);
        builder.Property(c => c.Speed);

        builder.HasMany(c => c.CharacterWeapons)
            .WithOne(cw => cw.Character)
            .HasForeignKey(cw => cw.CharacterId);
    }
}