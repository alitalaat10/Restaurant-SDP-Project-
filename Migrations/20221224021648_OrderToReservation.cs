using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace designpattern.Migrations
{
    /// <inheritdoc />
    public partial class OrderToReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tables_TableNumber",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TableNumber",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "TableNumber",
                table: "Orders",
                newName: "ReservationId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 12, 24, 2, 16, 47, 74, DateTimeKind.Utc).AddTicks(812), "$2a$11$dqxLwzpansp0W3F3cpx7sOLrW5S3Vq6q21Y5l62yfld.4gdthNf9y" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 12, 24, 2, 16, 46, 803, DateTimeKind.Utc).AddTicks(7583), "$2a$11$Xmu8ctuWdnckDsJXD3WmpOvEIBLNNGxLFEyHBf54cP14vPG5ZEEZu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 12, 24, 2, 16, 47, 510, DateTimeKind.Utc).AddTicks(9096), "$2a$11$eEWHEMmMaygSsiS4Yb4wx.SAzuuMxa.9mGPUZxk7sdjOfkl3peMl6" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ReservationId",
                table: "Orders",
                column: "ReservationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Reservations_ReservationId",
                table: "Orders",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Reservations_ReservationId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ReservationId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "Orders",
                newName: "TableNumber");

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TableNumber",
                table: "Orders",
                column: "TableNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tables_TableNumber",
                table: "Orders",
                column: "TableNumber",
                principalTable: "Tables",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
