using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApi.Migrations
{
    /// <inheritdoc />
    public partial class ModificationRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Role",
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

            migrationBuilder.CreateTable(
                name: "Relations",
                columns: table => new
                {
                    GuestsId = table.Column<int>(type: "INTEGER", nullable: false),
                    MoviesId = table.Column<int>(type: "INTEGER", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false),
                    GuestEntityId = table.Column<int>(type: "INTEGER", nullable: true),
                    MovieEntityId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => new { x.GuestsId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_Relations_Guests_GuestEntityId",
                        column: x => x.GuestEntityId,
                        principalTable: "Guests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Relations_Movies_MovieEntityId",
                        column: x => x.MovieEntityId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuestEntityMovieEntity_MoviesId",
                table: "GuestEntityMovieEntity",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_GuestEntityId",
                table: "Relations",
                column: "GuestEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_MovieEntityId",
                table: "Relations",
                column: "MovieEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestEntityMovieEntity");

            migrationBuilder.DropTable(
                name: "Relations");

            migrationBuilder.AddColumn<int>(
                name: "MovieEntityId",
                table: "Guests",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Guests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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
    }
}
