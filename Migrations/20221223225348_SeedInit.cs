using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace designpattern.Migrations
{
    /// <inheritdoc />
    public partial class SeedInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Name", "ManagerId" },
                values: new object[,]
                {
                    { "Egypt Branch", 2 },
                    { "Italy Branch", 1 },
                    { "Japan Branch", 3 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CreatedAt", "Email", "Name", "Password", "Phone", "Type" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2022, 12, 23, 22, 53, 46, 585, DateTimeKind.Utc).AddTicks(3970), "admin@gmail.com", "Admin", "$2a$11$66Wq7MDlaKunxxmjhvjgcOwE5dfvzn7i8ASOMtftJgNMzFTxV7EB.", "123456789", 0 },
                    { 2, true, new DateTime(2022, 12, 23, 22, 53, 46, 199, DateTimeKind.Utc).AddTicks(6031), "domafayrouz@gmail.com", "Adham Fayrouz", "$2a$11$CfYGWQxuR4tQ81.eNeFA1ua7uBlLUkMvIcjAAIadAe4dswDS2uJSq", "12345678", 1 },
                    { 3, true, new DateTime(2022, 12, 23, 22, 53, 46, 934, DateTimeKind.Utc).AddTicks(3507), "adhamfayrouz@gmail.com", "Adham Fayrouz", "$2a$11$dJkFlACorQUFNNDUSMeBfeZ2fWoyTgXgkNlmwG1.d6nRi1suhjU92", "1234567", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Name",
                keyValue: "Egypt Branch");

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Name",
                keyValue: "Italy Branch");

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Name",
                keyValue: "Japan Branch");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
