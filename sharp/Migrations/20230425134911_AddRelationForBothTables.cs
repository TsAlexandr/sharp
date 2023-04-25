using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sharp.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationForBothTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PostsViewModel_BlogId",
                table: "PostsViewModel",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostsViewModel_BlogsViewModel_BlogId",
                table: "PostsViewModel",
                column: "BlogId",
                principalTable: "BlogsViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostsViewModel_BlogsViewModel_BlogId",
                table: "PostsViewModel");

            migrationBuilder.DropIndex(
                name: "IX_PostsViewModel_BlogId",
                table: "PostsViewModel");
        }
    }
}
