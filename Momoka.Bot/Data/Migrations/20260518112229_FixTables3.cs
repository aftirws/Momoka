using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Momoka.Bot.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixTables3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fox_species_species_id",
                table: "fox");

            migrationBuilder.DropIndex(
                name: "IX_fox_species_id",
                table: "fox");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_fox_species_id",
                table: "fox",
                column: "species_id");

            migrationBuilder.AddForeignKey(
                name: "FK_fox_species_species_id",
                table: "fox",
                column: "species_id",
                principalTable: "species",
                principalColumn: "species_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
