using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameWorkDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbContract",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrgName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Registred = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Based = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ICO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepresentedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetANumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PSC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepresentedFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepresentedLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkStart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkEnd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreakStart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreakEnd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastChanged = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbContract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbContract_tbUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tbUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbContract_UserId",
                table: "tbContract",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbContract");

            migrationBuilder.DropTable(
                name: "tbUser");
        }
    }
}
