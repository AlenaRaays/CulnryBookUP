using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CulnryBookUP.Migrations
{
    /// <inheritdoc />
    public partial class CulinaryBook2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Recipes",
                type: "int",
                nullable: true,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "LoginModel",
                columns: table => new
                {
                    login = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleIdRole = table.Column<int>(type: "int", nullable: true),
                    IdRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginModel", x => x.login);
                    table.ForeignKey(
                        name: "FK_LoginModel_Roles_RoleIdRole",
                        column: x => x.RoleIdRole,
                        principalTable: "Roles",
                        principalColumn: "IdRole");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_IdUser",
                table: "Recipes",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_LoginModel_RoleIdRole",
                table: "LoginModel",
                column: "RoleIdRole");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Users_IdUser",
                table: "Recipes",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Users_IdUser",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "LoginModel");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_IdUser",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Recipes");
        }
    }
}
