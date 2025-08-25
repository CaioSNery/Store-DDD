using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infra.Migrations
{
    /// <inheritdoc />
    public partial class DeliveryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Orders",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 25, 15, 14, 1, 957, DateTimeKind.Utc).AddTicks(7246),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2025, 8, 24, 20, 28, 39, 382, DateTimeKind.Utc).AddTicks(2854));

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Payment = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliveries_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_OrderId",
                table: "Deliveries",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Orders",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 24, 20, 28, 39, 382, DateTimeKind.Utc).AddTicks(2854),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2025, 8, 25, 15, 14, 1, 957, DateTimeKind.Utc).AddTicks(7246));
        }
    }
}
