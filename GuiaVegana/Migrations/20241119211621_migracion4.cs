using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuiaVegana.Migrations
{
    /// <inheritdoc />
    public partial class migracion4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "InformativeResources",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "InformativeResources");
        }
    }
}
