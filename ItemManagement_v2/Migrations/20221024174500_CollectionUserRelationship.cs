using Microsoft.EntityFrameworkCore.Migrations;

namespace ItemManagement_v2.Migrations
{
    public partial class CollectionUserRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Collections",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Collections_IdentityUserId",
                table: "Collections",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_AspNetUsers_IdentityUserId",
                table: "Collections",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_AspNetUsers_IdentityUserId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Collections_IdentityUserId",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Collections");
        }
    }
}
