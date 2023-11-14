using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace designpattern.Migrations
{
    /// <inheritdoc />
    public partial class payments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreditCard = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfExpire = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CVV = table.Column<string>(type: "TEXT", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CreatedAt", "Email", "Name", "Password", "Phone", "Type" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2022, 12, 24, 2, 56, 53, 363, DateTimeKind.Utc).AddTicks(9636), "admin@gmail.com", "Admin", "$2a$11$gOI0eBZpR4LgQeHdJ8iYwOncYCBdKe0Gm8mc9yd175tl5qw97yqsW", "123456789", 0 },
                    { 2, true, new DateTime(2022, 12, 24, 2, 56, 53, 104, DateTimeKind.Utc).AddTicks(8858), "domafayrouz@gmail.com", "Adham Fayrouz", "$2a$11$VXpJ0eNNZDnrEy7HlqRwF.QMR1t/oPpY2REncZgX2Lcbv/TQqxS2e", "12345678", 1 },
                    { 3, true, new DateTime(2022, 12, 24, 2, 56, 53, 632, DateTimeKind.Utc).AddTicks(3873), "adhamfayrouz@gmail.com", "Adham Fayrouz", "$2a$11$L2N/HUGvbZJCkrnLoMyyrObeAaH0hM.tBdqzDF99JvjYDdatBULYa", "1234567", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Active",
                table: "Users",
                column: "Active");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Phone",
                table: "Users",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Type",
                table: "Users",
                column: "Type");
        }
    }
}
