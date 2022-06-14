using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kol2.Migrations
{
    public partial class MoreSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2022, 6, 14, 13, 41, 7, 112, DateTimeKind.Local).AddTicks(4194));

            migrationBuilder.InsertData(
                table: "Musician",
                columns: new[] { "IdMusician", "FirstName", "LastName", "Nickname" },
                values: new object[] { 2, "Malik", "Montana", null });

            migrationBuilder.InsertData(
                table: "Track",
                columns: new[] { "IdTrack", "Duration", "IdMusicAlbum", "TrackName" },
                values: new object[] { 2, 325f, null, "Wszystko dla rodziny" });

            migrationBuilder.InsertData(
                table: "Musician_Track",
                columns: new[] { "IdMusician", "IdTrack" },
                values: new object[] { 2, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Musician_Track",
                keyColumns: new[] { "IdMusician", "IdTrack" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Musician",
                keyColumn: "IdMusician",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "IdTrack",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2022, 6, 14, 13, 2, 15, 577, DateTimeKind.Local).AddTicks(3222));
        }
    }
}
