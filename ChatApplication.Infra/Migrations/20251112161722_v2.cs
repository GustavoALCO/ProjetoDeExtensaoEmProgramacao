using System;
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
                name: "FK_Mensage_Chat_ChatId",
                table: "Mensage");

            migrationBuilder.DropForeignKey(
                name: "FK_MensageStatus_Mensage_MensageId",
                table: "MensageStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_MensageStatus_User_UserId",
                table: "MensageStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MensageStatus",
                table: "MensageStatus");

            migrationBuilder.DropIndex(
                name: "IX_MensageStatus_UserId",
                table: "MensageStatus");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "MensageStatus",
                newName: "RecibeUserId");

            migrationBuilder.AlterColumn<Guid>(
                name: "MensageId",
                table: "MensageStatus",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ChatId",
                table: "Mensage",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Chat",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MensageStatus",
                table: "MensageStatus",
                column: "MensageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensage_Chat_ChatId",
                table: "Mensage",
                column: "ChatId",
                principalTable: "Chat",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MensageStatus_Mensage_MensageId",
                table: "MensageStatus",
                column: "MensageId",
                principalTable: "Mensage",
                principalColumn: "MensageId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensage_Chat_ChatId",
                table: "Mensage");

            migrationBuilder.DropForeignKey(
                name: "FK_MensageStatus_Mensage_MensageId",
                table: "MensageStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MensageStatus",
                table: "MensageStatus");

            migrationBuilder.RenameColumn(
                name: "RecibeUserId",
                table: "MensageStatus",
                newName: "UserId");

            migrationBuilder.AlterColumn<Guid>(
                name: "MensageId",
                table: "MensageStatus",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "ChatId",
                table: "Mensage",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Chat",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MensageStatus",
                table: "MensageStatus",
                columns: new[] { "MensageID", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_MensageStatus_UserId",
                table: "MensageStatus",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensage_Chat_ChatId",
                table: "Mensage",
                column: "ChatId",
                principalTable: "Chat",
                principalColumn: "ChatId");

            migrationBuilder.AddForeignKey(
                name: "FK_MensageStatus_Mensage_MensageId",
                table: "MensageStatus",
                column: "MensageId",
                principalTable: "Mensage",
                principalColumn: "MensageId");

            migrationBuilder.AddForeignKey(
                name: "FK_MensageStatus_User_UserId",
                table: "MensageStatus",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
