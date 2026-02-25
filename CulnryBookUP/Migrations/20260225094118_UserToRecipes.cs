using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CulnryBookUP.Migrations
{
    /// <inheritdoc />
    public partial class UserToRecipes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginModel_Roles_RoleIdRole",
                table: "LoginModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Categories_CategoryID",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleID",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "RoleID",
                table: "Users",
                newName: "IdRole");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                newName: "IX_Users_IdRole");

            migrationBuilder.RenameColumn(
                name: "RoleIdRole",
                table: "LoginModel",
                newName: "roleIdRole");

            migrationBuilder.RenameIndex(
                name: "IX_LoginModel_RoleIdRole",
                table: "LoginModel",
                newName: "IX_LoginModel_roleIdRole");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Recipes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginModel_Roles_roleIdRole",
                table: "LoginModel",
                column: "roleIdRole",
                principalTable: "Roles",
                principalColumn: "IdRole");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Categories_CategoryID",
                table: "Recipes",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "IdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_IdRole",
                table: "Users",
                column: "IdRole",
                principalTable: "Roles",
                principalColumn: "IdRole",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "LoginModel");

            migrationBuilder.DropForeignKey(
                name: "FK_LoginModel_Roles_roleIdRole",
                table: "LoginModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Categories_CategoryID",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_IdRole",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "IdRole",
                table: "Users",
                newName: "RoleID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_IdRole",
                table: "Users",
                newName: "IX_Users_RoleID");

            migrationBuilder.RenameColumn(
                name: "roleIdRole",
                table: "LoginModel",
                newName: "RoleIdRole");

            migrationBuilder.RenameIndex(
                name: "IX_LoginModel_roleIdRole",
                table: "LoginModel",
                newName: "IX_LoginModel_RoleIdRole");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LoginModel_Roles_RoleIdRole",
                table: "LoginModel",
                column: "RoleIdRole",
                principalTable: "Roles",
                principalColumn: "IdRole");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Categories_CategoryID",
                table: "Recipes",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "IdCategory",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleID",
                table: "Users",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "IdRole",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
