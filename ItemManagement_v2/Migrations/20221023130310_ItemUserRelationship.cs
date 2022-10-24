using Microsoft.EntityFrameworkCore.Migrations;

namespace ItemManagement_v2.Migrations
{
    public partial class ItemUserRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Items",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_IdentityUserId",
                table: "Items",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_AspNetUsers_IdentityUserId",
                table: "Items",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_AspNetUsers_IdentityUserId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_IdentityUserId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Items");
        }
    }
}
