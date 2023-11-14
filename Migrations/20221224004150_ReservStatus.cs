using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace designpattern.Migrations
{
    /// <inheritdoc />
    public partial class ReservStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Reservations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 12, 24, 0, 41, 49, 520, DateTimeKind.Utc).AddTicks(7702), "$2a$11$VFd371wMX5ilL3y0klqJe.53DMK9IbynTrfF/wTrUqcWCSfX7gE66" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 12, 24, 0, 41, 49, 249, DateTimeKind.Utc).AddTicks(5581), "$2a$11$BGpsNFKMrPCdbobywcuHoe4tCNN57NYD52b0tWJZchW1ba0L.T/0u" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 12, 24, 0, 41, 49, 790, DateTimeKind.Utc).AddTicks(4809), "$2a$11$H1wEy02fzmr4bBIjMqj41.EX9AvUgqrrKZYLuxV47vzdfJZwPL4We" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reservations");

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
        }
    }
}
