using Microsoft.EntityFrameworkCore.Migrations;

namespace Prueba.Repository.Migrations
{
    public partial class addColumnPan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Pan",
                table: "Cards",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pin",
                table: "Cards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pin",
                table: "Cards");

            migrationBuilder.AlterColumn<string>(
                name: "Pan",
                table: "Cards",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
