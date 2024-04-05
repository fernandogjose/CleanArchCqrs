using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchCqrs.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateTablePaymentProcessed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PaymentProcesseds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipmentsCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResourcesToAdd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentProcesseds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentProcesseds_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Email" },
                values: new object[] { new DateTime(2024, 4, 5, 14, 44, 6, 510, DateTimeKind.Local).AddTicks(7630), "fernandogjose@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Email" },
                values: new object[] { new DateTime(2024, 4, 5, 14, 44, 6, 510, DateTimeKind.Local).AddTicks(7646), "priscilaantunes@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Email" },
                values: new object[] { new DateTime(2024, 4, 5, 14, 44, 6, 510, DateTimeKind.Local).AddTicks(7647), "gabrielantunes@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Email" },
                values: new object[] { new DateTime(2024, 4, 5, 14, 44, 6, 510, DateTimeKind.Local).AddTicks(7648), "beatrizantunes@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 5, 14, 44, 6, 510, DateTimeKind.Local).AddTicks(9467));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 5, 14, 44, 6, 510, DateTimeKind.Local).AddTicks(9472));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 5, 14, 44, 6, 510, DateTimeKind.Local).AddTicks(9472));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 5, 14, 44, 6, 510, DateTimeKind.Local).AddTicks(9473));

            migrationBuilder.CreateIndex(
                name: "IX_PaymentProcesseds_PaymentId",
                table: "PaymentProcesseds",
                column: "PaymentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentProcesseds");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Agents");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 4, 10, 47, 18, 653, DateTimeKind.Local).AddTicks(7228));

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 4, 10, 47, 18, 653, DateTimeKind.Local).AddTicks(7244));

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 4, 10, 47, 18, 653, DateTimeKind.Local).AddTicks(7245));

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 4, 10, 47, 18, 653, DateTimeKind.Local).AddTicks(7245));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 4, 10, 47, 18, 653, DateTimeKind.Local).AddTicks(9027));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 4, 10, 47, 18, 653, DateTimeKind.Local).AddTicks(9032));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 4, 10, 47, 18, 653, DateTimeKind.Local).AddTicks(9033));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 4, 10, 47, 18, 653, DateTimeKind.Local).AddTicks(9034));
        }
    }
}
