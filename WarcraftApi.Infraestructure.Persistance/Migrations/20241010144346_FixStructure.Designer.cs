﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WarcraftApi.Infraestructure.Persistance.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241010144346_FixStructure")]
    partial class FixStructure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WarcraftApi.Infraestructure.Models.CharacterDm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Damage")
                        .HasColumnType("float");

                    b.Property<float>("Life")
                        .HasColumnType("float");

                    b.Property<string>("Lore")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<float>("Speed")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Characters", (string)null);
                });

            modelBuilder.Entity("WarcraftApi.Infraestructure.Models.CharacterWeaponDm", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("WeaponId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "WeaponId");

                    b.HasIndex("WeaponId");

                    b.ToTable("CharacterWeapons", (string)null);
                });

            modelBuilder.Entity("WarcraftApi.Infraestructure.Models.WeaponDm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Damage")
                        .HasColumnType("float");

                    b.Property<string>("Lore")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Weapons", (string)null);
                });

            modelBuilder.Entity("WarcraftApi.Infraestructure.Models.CharacterWeaponDm", b =>
                {
                    b.HasOne("WarcraftApi.Infraestructure.Models.CharacterDm", "Character")
                        .WithMany("CharacterWeapons")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarcraftApi.Infraestructure.Models.WeaponDm", "Weapon")
                        .WithMany("CharacterWeapons")
                        .HasForeignKey("WeaponId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("WarcraftApi.Infraestructure.Models.CharacterDm", b =>
                {
                    b.Navigation("CharacterWeapons");
                });

            modelBuilder.Entity("WarcraftApi.Infraestructure.Models.WeaponDm", b =>
                {
                    b.Navigation("CharacterWeapons");
                });
#pragma warning restore 612, 618
        }
    }
}
