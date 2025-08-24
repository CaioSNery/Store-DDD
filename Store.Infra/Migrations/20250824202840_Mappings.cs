using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Mappings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Orders",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 24, 20, 28, 39, 382, DateTimeKind.Utc).AddTicks(2854),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "NVARCHAR(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2025, 8, 24, 20, 28, 39, 382, DateTimeKind.Utc).AddTicks(2854));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(80)",
                oldMaxLength: 80);
        }
    }
}
