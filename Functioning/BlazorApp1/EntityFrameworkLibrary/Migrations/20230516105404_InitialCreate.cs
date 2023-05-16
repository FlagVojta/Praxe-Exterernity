using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    tbUserId = table.Column<int>(type: "int", nullable: true),
                    OrgName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Registred = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Based = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ICO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepresentedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetANumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PSC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepresentedFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepresentedLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkStart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkEnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreakStart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreakEnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastChanged = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbContract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbContract_tbUser_tbUserId",
                        column: x => x.tbUserId,
                        principalTable: "tbUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbContract_tbUserId",
                table: "tbContract",
                column: "tbUserId");
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
