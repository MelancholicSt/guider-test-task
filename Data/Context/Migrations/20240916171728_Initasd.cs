using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuiderTestTasj.Migrations
{
    /// <inheritdoc />
    public partial class Initasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "establishments",
                type: "varchar(3000)",
                maxLength: 3000,
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "establishments");
        }
    }
}
