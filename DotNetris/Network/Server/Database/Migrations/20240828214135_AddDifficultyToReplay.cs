using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetris.Network.Server.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddDifficultyToReplay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "RawDifficulty",
                table: "Replays",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RawDifficulty",
                table: "Replays");
        }
    }
}
