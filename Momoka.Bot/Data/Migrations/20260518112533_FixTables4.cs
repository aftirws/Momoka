using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Momoka.Bot.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixTables4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fox_species_species_id1",
                table: "fox");

            migrationBuilder.DropIndex(
                name: "IX_fox_species_id1",
                table: "fox");

            migrationBuilder.DropColumn(
                name: "species_id1",
                table: "fox");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "species",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "species_id",
                table: "species",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "fox",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "fox",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "fox",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "species_id",
                table: "fox",
                newName: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_fox_SpeciesId",
                table: "fox",
                column: "SpeciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_fox_species_SpeciesId",
                table: "fox",
                column: "SpeciesId",
                principalTable: "species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fox_species_SpeciesId",
                table: "fox");

            migrationBuilder.DropIndex(
                name: "IX_fox_SpeciesId",
                table: "fox");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "species",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "species",
                newName: "species_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "fox",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "fox",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "fox",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SpeciesId",
                table: "fox",
                newName: "species_id");

            migrationBuilder.AddColumn<int>(
                name: "species_id1",
                table: "fox",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_fox_species_id1",
                table: "fox",
                column: "species_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_fox_species_species_id1",
                table: "fox",
                column: "species_id1",
                principalTable: "species",
                principalColumn: "species_id");
        }
    }
}
