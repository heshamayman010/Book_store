using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore2.Migrations
{
    public partial class afterDepartments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Books",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "dptid",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookDepartment", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_dptid",
                table: "Books",
                column: "dptid");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookDepartment_dptid",
                table: "Books",
                column: "dptid",
                principalTable: "BookDepartment",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookDepartment_dptid",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BookDepartment");

            migrationBuilder.DropIndex(
                name: "IX_Books_dptid",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "dptid",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
