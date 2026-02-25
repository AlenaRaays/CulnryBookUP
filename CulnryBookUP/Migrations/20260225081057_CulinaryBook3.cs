using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CulnryBookUP.Migrations
{
    /// <inheritdoc />
    public partial class CulinaryBook3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Users_IdUser",
                table: "Recipes");

            migrationBuilder.AlterColumn<int>(
                name: "IdUser",
                table: "Recipes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Users_IdUser",
                table: "Recipes",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Users_IdUser",
                table: "Recipes");

            migrationBuilder.AlterColumn<int>(
                name: "IdUser",
                table: "Recipes",
                type: "int",
                nullable: true,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Users_IdUser",
                table: "Recipes",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
