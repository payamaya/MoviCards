using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCardsAPI.Migrations
{
    /// <inheritdoc />
    public partial class Detail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("163f98c2-be1c-4ed5-a748-740b5a79025a"), "Actor One" });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "ContactInformationId", "DateOfBirth", "Name" },
                values: new object[] { new Guid("96a40028-35a7-42a9-a23f-6c9ab6a58789"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Director One" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("57286e34-bb36-431e-8b4a-4595785c426a"), "Genre One" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("163f98c2-be1c-4ed5-a748-740b5a79025a"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("96a40028-35a7-42a9-a23f-6c9ab6a58789"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("57286e34-bb36-431e-8b4a-4595785c426a"));

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
    }
}
