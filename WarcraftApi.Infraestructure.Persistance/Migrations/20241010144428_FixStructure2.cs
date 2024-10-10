using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarcraftApi.Infraestructure.Persistance.Migrations
{
    public partial class FixStructure2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterWeapons_Characters_CharacterId",
                table: "CharacterWeapons");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterWeapons_Weapons_WeaponId",
                table: "CharacterWeapons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterWeapons",
                table: "CharacterWeapons");

            migrationBuilder.RenameTable(
                name: "CharacterWeapons",
                newName: "Character_Weapons");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterWeapons_WeaponId",
                table: "Character_Weapons",
                newName: "IX_Character_Weapons_WeaponId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Character_Weapons",
                table: "Character_Weapons",
                columns: new[] { "CharacterId", "WeaponId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Weapons_Characters_CharacterId",
                table: "Character_Weapons",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Weapons_Weapons_WeaponId",
                table: "Character_Weapons",
                column: "WeaponId",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Weapons_Characters_CharacterId",
                table: "Character_Weapons");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Weapons_Weapons_WeaponId",
                table: "Character_Weapons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Character_Weapons",
                table: "Character_Weapons");

            migrationBuilder.RenameTable(
                name: "Character_Weapons",
                newName: "CharacterWeapons");

            migrationBuilder.RenameIndex(
                name: "IX_Character_Weapons_WeaponId",
                table: "CharacterWeapons",
                newName: "IX_CharacterWeapons_WeaponId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterWeapons",
                table: "CharacterWeapons",
                columns: new[] { "CharacterId", "WeaponId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterWeapons_Characters_CharacterId",
                table: "CharacterWeapons",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterWeapons_Weapons_WeaponId",
                table: "CharacterWeapons",
                column: "WeaponId",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
