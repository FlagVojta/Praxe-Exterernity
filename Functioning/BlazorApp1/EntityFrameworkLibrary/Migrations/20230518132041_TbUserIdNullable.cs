using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkLibrary.Migrations
{
    /// <inheritdoc />
    public partial class TbUserIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_workDays_workRecords_WorkRecordId",
                table: "workDays");

            migrationBuilder.DropForeignKey(
                name: "FK_workRecords_tbUser_tbUserId",
                table: "workRecords");

            migrationBuilder.AlterColumn<int>(
                name: "tbUserId",
                table: "workRecords",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "WorkRecordId",
                table: "workDays",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_workDays_workRecords_WorkRecordId",
                table: "workDays",
                column: "WorkRecordId",
                principalTable: "workRecords",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_workRecords_tbUser_tbUserId",
                table: "workRecords",
                column: "tbUserId",
                principalTable: "tbUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_workDays_workRecords_WorkRecordId",
                table: "workDays");

            migrationBuilder.DropForeignKey(
                name: "FK_workRecords_tbUser_tbUserId",
                table: "workRecords");

            migrationBuilder.AlterColumn<int>(
                name: "tbUserId",
                table: "workRecords",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WorkRecordId",
                table: "workDays",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_workDays_workRecords_WorkRecordId",
                table: "workDays",
                column: "WorkRecordId",
                principalTable: "workRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workRecords_tbUser_tbUserId",
                table: "workRecords",
                column: "tbUserId",
                principalTable: "tbUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
