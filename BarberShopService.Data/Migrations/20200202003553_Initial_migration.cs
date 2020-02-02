using Microsoft.EntityFrameworkCore.Migrations;

namespace BarberShopService.Data.Migrations
{
    public partial class Initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BarberShops",
                columns: table => new
                {
                    BarberShopId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    OpeningTime = table.Column<string>(maxLength: 2, nullable: true),
                    ClosingTime = table.Column<string>(maxLength: 2, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    Rating = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    imagePath = table.Column<string>(nullable: true),
                    Closed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarberShops", x => x.BarberShopId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(maxLength: 20, nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Barbers",
                columns: table => new
                {
                    BarberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    NumberCell = table.Column<string>(maxLength: 14, nullable: true),
                    Rating = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    StartTime = table.Column<string>(maxLength: 2, nullable: true),
                    EndTime = table.Column<string>(maxLength: 2, nullable: true),
                    PhotoPath = table.Column<string>(maxLength: 500, nullable: true),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    BarberShopId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbers", x => x.BarberId);
                    table.ForeignKey(
                        name: "FK_Barbers_BarberShops_BarberShopId",
                        column: x => x.BarberShopId,
                        principalTable: "BarberShops",
                        principalColumn: "BarberShopId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Barbers_BarberShopId",
                table: "Barbers",
                column: "BarberShopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Barbers");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "BarberShops");
        }
    }
}
