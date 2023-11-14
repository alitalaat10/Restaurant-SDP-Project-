using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace designpattern.Migrations
{
    /// <inheritdoc />
    public partial class WorkerType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Workers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 12, 23, 23, 34, 38, 172, DateTimeKind.Utc).AddTicks(7107), "$2a$11$uvvKVkvODJNLB8XKhdRvlOOrhxKepYbmRHZbB4sFgibh.K.svU5sy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 12, 23, 23, 34, 37, 665, DateTimeKind.Utc).AddTicks(9156), "$2a$11$8joU.ZQT7eU3aXISdHuC4OvLvlcCpGgcDWUMfC6YaNbqH.o3fdJea" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 12, 23, 23, 34, 38, 677, DateTimeKind.Utc).AddTicks(5555), "$2a$11$5vlbQgM7pfAJLwWbZLFp6.DzpZQy5ZOYMAv.U3DsN.MRIDsacE3Qm" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Workers");

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
        }
    }
}
