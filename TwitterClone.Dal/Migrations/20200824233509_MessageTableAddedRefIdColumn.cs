using Microsoft.EntityFrameworkCore.Migrations;

namespace TwitterClone.Dal.Migrations
{
    public partial class MessageTableAddedRefIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RefId",
                table: "Messages",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefId",
                table: "Messages");
        }
    }
}
