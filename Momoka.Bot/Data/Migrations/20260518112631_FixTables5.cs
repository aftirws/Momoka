using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Momoka.Bot.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixTables5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fox_species_SpeciesId",
                table: "fox");

            migrationBuilder.DropPrimaryKey(
                name: "PK_species",
                table: "species");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fox",
                table: "fox");

            migrationBuilder.RenameTable(
                name: "species",
                newName: "Species");

            migrationBuilder.RenameTable(
                name: "fox",
                newName: "Foxes");

            migrationBuilder.RenameIndex(
                name: "IX_fox_SpeciesId",
                table: "Foxes",
                newName: "IX_Foxes_SpeciesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Species",
                table: "Species",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foxes",
                table: "Foxes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Foxes_Species_SpeciesId",
                table: "Foxes",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foxes_Species_SpeciesId",
                table: "Foxes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Species",
                table: "Species");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foxes",
                table: "Foxes");

            migrationBuilder.RenameTable(
                name: "Species",
                newName: "species");

            migrationBuilder.RenameTable(
                name: "Foxes",
                newName: "fox");

            migrationBuilder.RenameIndex(
                name: "IX_Foxes_SpeciesId",
                table: "fox",
                newName: "IX_fox_SpeciesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_species",
                table: "species",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fox",
                table: "fox",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_fox_species_SpeciesId",
                table: "fox",
                column: "SpeciesId",
                principalTable: "species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
