using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailSender.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdedToMailClientEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Clients");
        }
    }
}
