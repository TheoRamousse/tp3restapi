using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGuestAndMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestEntityMovieEntity");

            migrationBuilder.AddColumn<int>(
                name: "MovieEntityId",
                table: "Guests",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guests_MovieEntityId",
                table: "Guests",
                column: "MovieEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Movies_MovieEntityId",
                table: "Guests",
                column: "MovieEntityId",
                principalTable: "Movies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Movies_MovieEntityId",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_MovieEntityId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "MovieEntityId",
                table: "Guests");

            migrationBuilder.CreateTable(
                name: "GuestEntityMovieEntity",
                columns: table => new
                {
                    GuestsId = table.Column<int>(type: "INTEGER", nullable: false),
                    MoviesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestEntityMovieEntity", x => new { x.GuestsId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_GuestEntityMovieEntity_Guests_GuestsId",
                        column: x => x.GuestsId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestEntityMovieEntity_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuestEntityMovieEntity_MoviesId",
                table: "GuestEntityMovieEntity",
                column: "MoviesId");
        }
    }
}
