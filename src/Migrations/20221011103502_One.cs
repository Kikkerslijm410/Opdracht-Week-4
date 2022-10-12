using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace opdrachtweek4.Migrations
{
    public partial class One : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DbGebruiker",
                table: "DbGebruiker");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DbGebruiker");

            migrationBuilder.RenameTable(
                name: "DbGebruiker",
                newName: "Gebruiker");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Gebruiker",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gebruiker",
                table: "Gebruiker",
                column: "Email");

            migrationBuilder.CreateTable(
                name: "DbGastInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbGastInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medewerker",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medewerker", x => x.Email);
                    table.ForeignKey(
                        name: "FK_Medewerker_Gebruiker_Email",
                        column: x => x.Email,
                        principalTable: "Gebruiker",
                        principalColumn: "Email");
                });

            migrationBuilder.CreateTable(
                name: "Attractie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reserveringId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attractie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gast",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    GastinfoId = table.Column<int>(type: "int", nullable: false),
                    Geboortedatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EersteBezoek = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BegeleiderEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FavorieteAttractieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gast", x => x.Email);
                    table.ForeignKey(
                        name: "FK_Gast_Attractie_FavorieteAttractieId",
                        column: x => x.FavorieteAttractieId,
                        principalTable: "Attractie",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Gast_DbGastInfo_GastinfoId",
                        column: x => x.GastinfoId,
                        principalTable: "DbGastInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gast_Gast_BegeleiderEmail",
                        column: x => x.BegeleiderEmail,
                        principalTable: "Gast",
                        principalColumn: "Email");
                    table.ForeignKey(
                        name: "FK_Gast_Gebruiker_Email",
                        column: x => x.Email,
                        principalTable: "Gebruiker",
                        principalColumn: "Email");
                });

            migrationBuilder.CreateTable(
                name: "Onderhoud",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    probleem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DTB_Onderhoud_Begin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DTB_Onderhoud_Eind = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onderhoud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Onderhoud_Attractie_Id",
                        column: x => x.Id,
                        principalTable: "Attractie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbReservering",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Gast = table.Column<int>(type: "int", nullable: false),
                    gastEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DTB_Reservering_Begin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DTB_Reservering_Eind = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbReservering", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbReservering_Gast_gastEmail",
                        column: x => x.gastEmail,
                        principalTable: "Gast",
                        principalColumn: "Email");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attractie_reserveringId",
                table: "Attractie",
                column: "reserveringId");

            migrationBuilder.CreateIndex(
                name: "IX_DbReservering_gastEmail",
                table: "DbReservering",
                column: "gastEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Gast_BegeleiderEmail",
                table: "Gast",
                column: "BegeleiderEmail",
                unique: true,
                filter: "[BegeleiderEmail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Gast_FavorieteAttractieId",
                table: "Gast",
                column: "FavorieteAttractieId");

            migrationBuilder.CreateIndex(
                name: "IX_Gast_GastinfoId",
                table: "Gast",
                column: "GastinfoId",
                unique: true,
                filter: "[GastinfoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Attractie_DbReservering_reserveringId",
                table: "Attractie",
                column: "reserveringId",
                principalTable: "DbReservering",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attractie_DbReservering_reserveringId",
                table: "Attractie");

            migrationBuilder.DropTable(
                name: "Medewerker");

            migrationBuilder.DropTable(
                name: "Onderhoud");

            migrationBuilder.DropTable(
                name: "DbReservering");

            migrationBuilder.DropTable(
                name: "Gast");

            migrationBuilder.DropTable(
                name: "Attractie");

            migrationBuilder.DropTable(
                name: "DbGastInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gebruiker",
                table: "Gebruiker");

            migrationBuilder.RenameTable(
                name: "Gebruiker",
                newName: "DbGebruiker");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "DbGebruiker",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DbGebruiker",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbGebruiker",
                table: "DbGebruiker",
                column: "Id");
        }
    }
}
