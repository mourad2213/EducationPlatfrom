using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToLearner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Learner",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Learner_UserId",
                table: "Learner",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Learner_AspNetUsers_UserId",
                table: "Learner",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Learner_AspNetUsers_UserId",
                table: "Learner");

            migrationBuilder.DropIndex(
                name: "IX_Learner_UserId",
                table: "Learner");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Learner");
        }
    }
}
