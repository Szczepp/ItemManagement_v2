using Microsoft.EntityFrameworkCore.Migrations;

namespace ItemManagement_v2.Migrations
{
    public partial class CustomUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_AspNetUsers_IdentityUserId",
                table: "Collections");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_AspNetUsers_IdentityUserId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "IdentityUserId",
                table: "Items",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_IdentityUserId",
                table: "Items",
                newName: "IX_Items_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "IdentityUserId",
                table: "Collections",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Collections_IdentityUserId",
                table: "Collections",
                newName: "IX_Collections_ApplicationUserId");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_AspNetUsers_ApplicationUserId",
                table: "Collections",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_AspNetUsers_ApplicationUserId",
                table: "Items",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_AspNetUsers_ApplicationUserId",
                table: "Collections");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_AspNetUsers_ApplicationUserId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Items",
                newName: "IdentityUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ApplicationUserId",
                table: "Items",
                newName: "IX_Items_IdentityUserId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Collections",
                newName: "IdentityUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Collections_ApplicationUserId",
                table: "Collections",
                newName: "IX_Collections_IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_AspNetUsers_IdentityUserId",
                table: "Collections",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_AspNetUsers_IdentityUserId",
                table: "Items",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
