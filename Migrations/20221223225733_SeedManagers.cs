using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace designpattern.Migrations
{
    /// <inheritdoc />
    public partial class SeedManagers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 12, 23, 22, 57, 32, 123, DateTimeKind.Utc).AddTicks(2323), "$2a$11$3J99FKNgSBfxI2yVDtJOsuPr4PNd7.KNDwaKCM5YozZIGweTO9UsG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 12, 23, 22, 57, 31, 776, DateTimeKind.Utc).AddTicks(3411), "$2a$11$p3/rXjw6YZ73iqV.hiOetuTZ7Dy66nGf8nT/84qwuQfKPtRZttBFu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 12, 23, 22, 57, 32, 464, DateTimeKind.Utc).AddTicks(2025), "$2a$11$JHw65kNWYBK8dXpovUNZaOmmDLZJSXf4wZQPe/Jixght10Y6i1cj2" });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "BranchName", "salary", "workerName" },
                values: new object[,]
                {
                    { 1, "Italy Branch", 3000, "Alberto" },
                    { 2, "Egypt Branch", 2500, "Ali" },
                    { 3, "Japan Branch", 10000, "Tanaka" }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                column: "Id",
                values: new object[]
                {
                    1,
                    2,
                    3
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 12, 23, 22, 53, 46, 585, DateTimeKind.Utc).AddTicks(3970), "$2a$11$66Wq7MDlaKunxxmjhvjgcOwE5dfvzn7i8ASOMtftJgNMzFTxV7EB." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 12, 23, 22, 53, 46, 199, DateTimeKind.Utc).AddTicks(6031), "$2a$11$CfYGWQxuR4tQ81.eNeFA1ua7uBlLUkMvIcjAAIadAe4dswDS2uJSq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 12, 23, 22, 53, 46, 934, DateTimeKind.Utc).AddTicks(3507), "$2a$11$dJkFlACorQUFNNDUSMeBfeZ2fWoyTgXgkNlmwG1.d6nRi1suhjU92" });
        }
    }
}
