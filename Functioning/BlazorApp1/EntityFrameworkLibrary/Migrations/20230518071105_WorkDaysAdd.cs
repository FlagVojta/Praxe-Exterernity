using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkLibrary.Migrations
{
    /// <inheritdoc />
    public partial class WorkDaysAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "workRecords");

            migrationBuilder.DropColumn(
                name: "WorkDescription",
                table: "workRecords");

            migrationBuilder.DropColumn(
                name: "WorkTime",
                table: "workRecords");

            migrationBuilder.AddColumn<string>(
                name: "ReviewOfCompany",
                table: "workRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReviewOfStudent",
                table: "workRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "workDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    workRecordsId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkRecordId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_workDays_workRecords_WorkRecordId",
                        column: x => x.WorkRecordId,
                        principalTable: "workRecords",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_workDays_WorkRecordId",
                table: "workDays",
                column: "WorkRecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "workDays");

            migrationBuilder.DropColumn(
                name: "ReviewOfCompany",
                table: "workRecords");

            migrationBuilder.DropColumn(
                name: "ReviewOfStudent",
                table: "workRecords");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "workRecords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "WorkDescription",
                table: "workRecords",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkTime",
                table: "workRecords",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
