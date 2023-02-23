using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShowroom.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Showrooms",
                columns: table => new
                {
                    ShowroomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowroomName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ShowroomPhone = table.Column<int>(type: "int", maxLength: 16, nullable: true),
                    ShowroomAddress = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Showrooms", x => x.ShowroomId);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    ModelYear = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    EngineCapacity = table.Column<int>(type: "int", maxLength: 5, nullable: true),
                    Price = table.Column<int>(type: "int", maxLength: 16, nullable: true),
                    ShowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Showrooms_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Showrooms",
                        principalColumn: "ShowroomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ShowId",
                table: "Cars",
                column: "ShowId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Showrooms");
        }
    }
}
