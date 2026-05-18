using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Momoka.Bot.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_account_Species_SpeciesId",
                table: "user_account");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Species",
                table: "Species");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_account",
                table: "user_account");

            migrationBuilder.RenameTable(
                name: "Species",
                newName: "species");

            migrationBuilder.RenameTable(
                name: "user_account",
                newName: "fox");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "species",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "species",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_user_account_SpeciesId",
                table: "fox",
                newName: "IX_fox_SpeciesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_species",
                table: "species",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fox",
                table: "fox",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_fox_species_SpeciesId",
                table: "fox",
                column: "SpeciesId",
                principalTable: "species",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "user_account");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Species",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Species",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_fox_SpeciesId",
                table: "user_account",
                newName: "IX_user_account_SpeciesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Species",
                table: "Species",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_account",
                table: "user_account",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_account_Species_SpeciesId",
                table: "user_account",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
