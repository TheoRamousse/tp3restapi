using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Guests_GuestEntityId",
                table: "Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Movies_MovieEntityId",
                table: "Relations");

            migrationBuilder.DropIndex(
                name: "IX_Relations_GuestEntityId",
                table: "Relations");

            migrationBuilder.DropIndex(
                name: "IX_Relations_MovieEntityId",
                table: "Relations");

            migrationBuilder.DropColumn(
                name: "GuestEntityId",
                table: "Relations");

            migrationBuilder.DropColumn(
                name: "MovieEntityId",
                table: "Relations");

            migrationBuilder.RenameColumn(
                name: "MoviesId",
                table: "Relations",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "GuestsId",
                table: "Relations",
                newName: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_MovieId",
                table: "Relations",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Guests_GuestId",
                table: "Relations",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Movies_MovieId",
                table: "Relations",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Guests_GuestId",
                table: "Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Movies_MovieId",
                table: "Relations");

            migrationBuilder.DropIndex(
                name: "IX_Relations_MovieId",
                table: "Relations");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Relations",
                newName: "MoviesId");

            migrationBuilder.RenameColumn(
                name: "GuestId",
                table: "Relations",
                newName: "GuestsId");

            migrationBuilder.AddColumn<int>(
                name: "GuestEntityId",
                table: "Relations",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieEntityId",
                table: "Relations",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Relations_GuestEntityId",
                table: "Relations",
                column: "GuestEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_MovieEntityId",
                table: "Relations",
                column: "MovieEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Guests_GuestEntityId",
                table: "Relations",
                column: "GuestEntityId",
                principalTable: "Guests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Movies_MovieEntityId",
                table: "Relations",
                column: "MovieEntityId",
                principalTable: "Movies",
                principalColumn: "Id");
        }
    }
}
