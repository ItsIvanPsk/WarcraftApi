using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarcraftApi.Infraestructure.Persistance.Migrations
{
    public partial class FixStructure3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "Characters_Weapons");

            migrationBuilder.RenameIndex(
                name: "IX_Character_Weapons_WeaponId",
                table: "Characters_Weapons",
                newName: "IX_Characters_Weapons_WeaponId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Characters_Weapons",
                table: "Characters_Weapons",
                columns: new[] { "CharacterId", "WeaponId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Weapons_Characters_CharacterId",
                table: "Characters_Weapons",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Weapons_Weapons_WeaponId",
                table: "Characters_Weapons",
                column: "WeaponId",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Weapons_Characters_CharacterId",
                table: "Characters_Weapons");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Weapons_Weapons_WeaponId",
                table: "Characters_Weapons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Characters_Weapons",
                table: "Characters_Weapons");

            migrationBuilder.RenameTable(
                name: "Characters_Weapons",
                newName: "Character_Weapons");

            migrationBuilder.RenameIndex(
                name: "IX_Characters_Weapons_WeaponId",
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
    }
}
