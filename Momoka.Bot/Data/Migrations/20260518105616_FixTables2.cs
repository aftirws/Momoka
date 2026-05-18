using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Momoka.Bot.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fox_species_SpeciesId",
                table: "fox");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "species",
                newName: "species_id");

            migrationBuilder.RenameColumn(
                name: "SpeciesId",
                table: "fox",
                newName: "species_id");

            migrationBuilder.RenameIndex(
                name: "IX_fox_SpeciesId",
                table: "fox",
                newName: "IX_fox_species_id");

            migrationBuilder.AddForeignKey(
                name: "FK_fox_species_species_id",
                table: "fox",
                column: "species_id",
                principalTable: "species",
                principalColumn: "species_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fox_species_species_id",
                table: "fox");

            migrationBuilder.RenameColumn(
                name: "species_id",
                table: "species",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "species_id",
                table: "fox",
                newName: "SpeciesId");

            migrationBuilder.RenameIndex(
                name: "IX_fox_species_id",
                table: "fox",
                newName: "IX_fox_SpeciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_fox_species_SpeciesId",
                table: "fox",
                column: "SpeciesId",
                principalTable: "species",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
