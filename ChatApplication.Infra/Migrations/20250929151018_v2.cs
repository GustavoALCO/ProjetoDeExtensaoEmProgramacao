using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatApplication.Infra.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatUsers_Chat_ChatId",
                table: "ChatUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatUsers_User_UserId",
                table: "ChatUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatUsers",
                table: "ChatUsers");

            migrationBuilder.RenameTable(
                name: "ChatUsers",
                newName: "chatUsers");

            migrationBuilder.RenameIndex(
                name: "IX_ChatUsers_UserId",
                table: "chatUsers",
                newName: "IX_chatUsers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_chatUsers",
                table: "chatUsers",
                columns: new[] { "ChatId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_chatUsers_Chat_ChatId",
                table: "chatUsers",
                column: "ChatId",
                principalTable: "Chat",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_chatUsers_User_UserId",
                table: "chatUsers",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chatUsers_Chat_ChatId",
                table: "chatUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_chatUsers_User_UserId",
                table: "chatUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_chatUsers",
                table: "chatUsers");

            migrationBuilder.RenameTable(
                name: "chatUsers",
                newName: "ChatUsers");

            migrationBuilder.RenameIndex(
                name: "IX_chatUsers_UserId",
                table: "ChatUsers",
                newName: "IX_ChatUsers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatUsers",
                table: "ChatUsers",
                columns: new[] { "ChatId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUsers_Chat_ChatId",
                table: "ChatUsers",
                column: "ChatId",
                principalTable: "Chat",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUsers_User_UserId",
                table: "ChatUsers",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
