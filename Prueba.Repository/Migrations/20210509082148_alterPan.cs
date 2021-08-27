using Microsoft.EntityFrameworkCore.Migrations;

namespace Prueba.Repository.Migrations
{
    public partial class alterPan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Pan",
                table: "Cards",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Pan",
                table: "Cards",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
