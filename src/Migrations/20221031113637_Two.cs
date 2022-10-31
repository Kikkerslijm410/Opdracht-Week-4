using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace opdrachtweek4.Migrations
{
    public partial class Two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attractie_DbReservering_reserveringId",
                table: "Attractie");

            migrationBuilder.DropIndex(
                name: "IX_Attractie_reserveringId",
                table: "Attractie");

            migrationBuilder.DropColumn(
                name: "reserveringId",
                table: "Attractie");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DTB_Reservering_Eind",
                table: "DbReservering",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DTB_Reservering_Begin",
                table: "DbReservering",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GereserverdeAttractiesId",
                table: "DbReservering",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DbReservering_GereserverdeAttractiesId",
                table: "DbReservering",
                column: "GereserverdeAttractiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbReservering_Attractie_GereserverdeAttractiesId",
                table: "DbReservering",
                column: "GereserverdeAttractiesId",
                principalTable: "Attractie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbReservering_Attractie_GereserverdeAttractiesId",
                table: "DbReservering");

            migrationBuilder.DropIndex(
                name: "IX_DbReservering_GereserverdeAttractiesId",
                table: "DbReservering");

            migrationBuilder.DropColumn(
                name: "GereserverdeAttractiesId",
                table: "DbReservering");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DTB_Reservering_Eind",
                table: "DbReservering",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DTB_Reservering_Begin",
                table: "DbReservering",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "reserveringId",
                table: "Attractie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attractie_reserveringId",
                table: "Attractie",
                column: "reserveringId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attractie_DbReservering_reserveringId",
                table: "Attractie",
                column: "reserveringId",
                principalTable: "DbReservering",
                principalColumn: "Id");
        }
    }
}
