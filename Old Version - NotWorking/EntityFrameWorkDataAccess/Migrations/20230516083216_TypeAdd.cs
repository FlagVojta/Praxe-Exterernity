using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameWorkDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TypeAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "tbUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "tbUser");
        }
    }
}
