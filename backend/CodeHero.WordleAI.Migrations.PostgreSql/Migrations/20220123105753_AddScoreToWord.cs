using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeHero.WordleAI.Migrations.PostgreSql.Migrations
{
    public partial class AddScoreToWord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Characters",
                table: "word",
                type: "character varying(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<double>(
                name: "Score",
                table: "word",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "word");

            migrationBuilder.AlterColumn<string>(
                name: "Characters",
                table: "word",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(6)",
                oldMaxLength: 6);
        }
    }
}
