using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkLibrary.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWorkDays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_workDays_workRecords_WorkRecordId",
                table: "workDays");

            migrationBuilder.DropColumn(
                name: "workRecordsId",
                table: "workDays");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_workDays_workRecords_WorkRecordId",
                table: "workDays");

            migrationBuilder.AlterColumn<int>(
                name: "WorkRecordId",
                table: "workDays",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "workRecordsId",
                table: "workDays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_workDays_workRecords_WorkRecordId",
                table: "workDays",
                column: "WorkRecordId",
                principalTable: "workRecords",
                principalColumn: "Id");
        }
    }
}
