using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkLibrary.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationFormUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_applications_tbUser_tbUserId",
                table: "applications");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "applications");

            migrationBuilder.AlterColumn<int>(
                name: "tbUserId",
                table: "applications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_applications_tbUser_tbUserId",
                table: "applications",
                column: "tbUserId",
                principalTable: "tbUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_applications_tbUser_tbUserId",
                table: "applications");

            migrationBuilder.AlterColumn<int>(
                name: "tbUserId",
                table: "applications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "applications",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_applications_tbUser_tbUserId",
                table: "applications",
                column: "tbUserId",
                principalTable: "tbUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
