using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Momoka.Bot.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foxes_Species_SpeciesId",
                table: "Foxes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foxes",
                table: "Foxes");

            migrationBuilder.RenameTable(
                name: "Foxes",
                newName: "user_account");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "user_account",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "user_account",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user_account",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Foxes_SpeciesId",
                table: "user_account",
                newName: "IX_user_account_SpeciesId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_account_Species_SpeciesId",
                table: "user_account");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_account",
                table: "user_account");

            migrationBuilder.RenameTable(
                name: "user_account",
                newName: "Foxes");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Foxes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "Foxes",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Foxes",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_user_account_SpeciesId",
                table: "Foxes",
                newName: "IX_Foxes_SpeciesId");

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
    }
}
