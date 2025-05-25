using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace training.Migrations.AuthTrainingDB
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roleclaims_roles_RoleId",
                table: "roleclaims");

            migrationBuilder.DropForeignKey(
                name: "FK_userclaims_users_UserId",
                table: "userclaims");

            migrationBuilder.DropForeignKey(
                name: "FK_userlogins_users_UserId",
                table: "userlogins");

            migrationBuilder.DropForeignKey(
                name: "FK_userroles_roles_RoleId",
                table: "userroles");

            migrationBuilder.DropForeignKey(
                name: "FK_userroles_users_UserId",
                table: "userroles");

            migrationBuilder.DropForeignKey(
                name: "FK_usertokens_users_UserId",
                table: "usertokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usertokens",
                table: "usertokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userroles",
                table: "userroles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userlogins",
                table: "userlogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userclaims",
                table: "userclaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roleclaims",
                table: "roleclaims");

            migrationBuilder.RenameTable(
                name: "usertokens",
                newName: "dara_usertokens");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "dara_users");

            migrationBuilder.RenameTable(
                name: "userroles",
                newName: "dara_userroles");

            migrationBuilder.RenameTable(
                name: "userlogins",
                newName: "dara_userlogins");

            migrationBuilder.RenameTable(
                name: "userclaims",
                newName: "dara_userclaims");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "dara_roles");

            migrationBuilder.RenameTable(
                name: "roleclaims",
                newName: "dara_roleclaims");

            migrationBuilder.RenameIndex(
                name: "IX_userroles_RoleId",
                table: "dara_userroles",
                newName: "IX_dara_userroles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_userlogins_UserId",
                table: "dara_userlogins",
                newName: "IX_dara_userlogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_userclaims_UserId",
                table: "dara_userclaims",
                newName: "IX_dara_userclaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_roleclaims_RoleId",
                table: "dara_roleclaims",
                newName: "IX_dara_roleclaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dara_usertokens",
                table: "dara_usertokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_dara_users",
                table: "dara_users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dara_userroles",
                table: "dara_userroles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_dara_userlogins",
                table: "dara_userlogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_dara_userclaims",
                table: "dara_userclaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dara_roles",
                table: "dara_roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dara_roleclaims",
                table: "dara_roleclaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_dara_roleclaims_dara_roles_RoleId",
                table: "dara_roleclaims",
                column: "RoleId",
                principalTable: "dara_roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dara_userclaims_dara_users_UserId",
                table: "dara_userclaims",
                column: "UserId",
                principalTable: "dara_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dara_userlogins_dara_users_UserId",
                table: "dara_userlogins",
                column: "UserId",
                principalTable: "dara_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dara_userroles_dara_roles_RoleId",
                table: "dara_userroles",
                column: "RoleId",
                principalTable: "dara_roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dara_userroles_dara_users_UserId",
                table: "dara_userroles",
                column: "UserId",
                principalTable: "dara_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dara_usertokens_dara_users_UserId",
                table: "dara_usertokens",
                column: "UserId",
                principalTable: "dara_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dara_roleclaims_dara_roles_RoleId",
                table: "dara_roleclaims");

            migrationBuilder.DropForeignKey(
                name: "FK_dara_userclaims_dara_users_UserId",
                table: "dara_userclaims");

            migrationBuilder.DropForeignKey(
                name: "FK_dara_userlogins_dara_users_UserId",
                table: "dara_userlogins");

            migrationBuilder.DropForeignKey(
                name: "FK_dara_userroles_dara_roles_RoleId",
                table: "dara_userroles");

            migrationBuilder.DropForeignKey(
                name: "FK_dara_userroles_dara_users_UserId",
                table: "dara_userroles");

            migrationBuilder.DropForeignKey(
                name: "FK_dara_usertokens_dara_users_UserId",
                table: "dara_usertokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dara_usertokens",
                table: "dara_usertokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dara_users",
                table: "dara_users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dara_userroles",
                table: "dara_userroles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dara_userlogins",
                table: "dara_userlogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dara_userclaims",
                table: "dara_userclaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dara_roles",
                table: "dara_roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dara_roleclaims",
                table: "dara_roleclaims");

            migrationBuilder.RenameTable(
                name: "dara_usertokens",
                newName: "usertokens");

            migrationBuilder.RenameTable(
                name: "dara_users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "dara_userroles",
                newName: "userroles");

            migrationBuilder.RenameTable(
                name: "dara_userlogins",
                newName: "userlogins");

            migrationBuilder.RenameTable(
                name: "dara_userclaims",
                newName: "userclaims");

            migrationBuilder.RenameTable(
                name: "dara_roles",
                newName: "roles");

            migrationBuilder.RenameTable(
                name: "dara_roleclaims",
                newName: "roleclaims");

            migrationBuilder.RenameIndex(
                name: "IX_dara_userroles_RoleId",
                table: "userroles",
                newName: "IX_userroles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_dara_userlogins_UserId",
                table: "userlogins",
                newName: "IX_userlogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_dara_userclaims_UserId",
                table: "userclaims",
                newName: "IX_userclaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_dara_roleclaims_RoleId",
                table: "roleclaims",
                newName: "IX_roleclaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usertokens",
                table: "usertokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userroles",
                table: "userroles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_userlogins",
                table: "userlogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_userclaims",
                table: "userclaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roleclaims",
                table: "roleclaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_roleclaims_roles_RoleId",
                table: "roleclaims",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userclaims_users_UserId",
                table: "userclaims",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userlogins_users_UserId",
                table: "userlogins",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userroles_roles_RoleId",
                table: "userroles",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userroles_users_UserId",
                table: "userroles",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usertokens_users_UserId",
                table: "usertokens",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
