using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace designpattern.Migrations
{
    /// <inheritdoc />
    public partial class OrderMealItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 12, 24, 2, 56, 53, 363, DateTimeKind.Utc).AddTicks(9636), "$2a$11$gOI0eBZpR4LgQeHdJ8iYwOncYCBdKe0Gm8mc9yd175tl5qw97yqsW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 12, 24, 2, 56, 53, 104, DateTimeKind.Utc).AddTicks(8858), "$2a$11$VXpJ0eNNZDnrEy7HlqRwF.QMR1t/oPpY2REncZgX2Lcbv/TQqxS2e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 12, 24, 2, 56, 53, 632, DateTimeKind.Utc).AddTicks(3873), "$2a$11$L2N/HUGvbZJCkrnLoMyyrObeAaH0hM.tBdqzDF99JvjYDdatBULYa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
