using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchCqrs.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterTablePaymentAddStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Payments");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 3, 22, 38, 18, 809, DateTimeKind.Local).AddTicks(5223));

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 3, 22, 38, 18, 809, DateTimeKind.Local).AddTicks(5235));

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 3, 22, 38, 18, 809, DateTimeKind.Local).AddTicks(5236));

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 3, 22, 38, 18, 809, DateTimeKind.Local).AddTicks(5237));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 3, 22, 38, 18, 809, DateTimeKind.Local).AddTicks(6825));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 3, 22, 38, 18, 809, DateTimeKind.Local).AddTicks(6830));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 3, 22, 38, 18, 809, DateTimeKind.Local).AddTicks(6831));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 3, 22, 38, 18, 809, DateTimeKind.Local).AddTicks(6831));
        }
    }
}
