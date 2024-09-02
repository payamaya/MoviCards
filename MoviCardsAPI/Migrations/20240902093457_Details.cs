using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCardsAPI.Migrations
{
    /// <inheritdoc />
    public partial class Details : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("f1239c30-36ef-4229-a8dd-73594fe5d4f4"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("10ad7235-f92a-4317-95fd-78849aae9c8d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("30ebcc29-597e-4188-ae2a-fefefec639d8"));

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("27c1df6b-29a2-47d4-aa73-9878de661727"), "Actor One" });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "ContactInformationId", "DateOfBirth", "Name" },
                values: new object[] { new Guid("e24b0650-e7d3-4910-9878-cd92772fbff2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Director One" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("df7a7b3f-7eb6-4861-a769-e2bc92172ae5"), "Genre One" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("27c1df6b-29a2-47d4-aa73-9878de661727"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("e24b0650-e7d3-4910-9878-cd92772fbff2"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("df7a7b3f-7eb6-4861-a769-e2bc92172ae5"));

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f1239c30-36ef-4229-a8dd-73594fe5d4f4"), "Actor One" });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "ContactInformationId", "DateOfBirth", "Name" },
                values: new object[] { new Guid("10ad7235-f92a-4317-95fd-78849aae9c8d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Director One" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("30ebcc29-597e-4188-ae2a-fefefec639d8"), "Genre One" });
        }
    }
}
