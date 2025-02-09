using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FCUnirea.Persistance.Data.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 9, 19, 35, 1, 61, DateTimeKind.Utc).AddTicks(6509));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "GameDate",
                value: new DateTime(2025, 2, 9, 19, 35, 1, 61, DateTimeKind.Utc).AddTicks(6419));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 9, 19, 35, 1, 61, DateTimeKind.Utc).AddTicks(6491));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateReservation",
                value: new DateTime(2025, 2, 9, 19, 35, 1, 61, DateTimeKind.Utc).AddTicks(6434));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 9, 19, 35, 1, 61, DateTimeKind.Utc).AddTicks(6313));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 9, 19, 35, 1, 61, DateTimeKind.Utc).AddTicks(6316));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromStaffId = table.Column<int>(type: "int", nullable: true),
                    ToPlayerId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Review = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedback_Users_FromStaffId",
                        column: x => x.FromStaffId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedback_Users_ToPlayerId",
                        column: x => x.ToPlayerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 6, 11, 29, 16, 866, DateTimeKind.Utc).AddTicks(8538));

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "Id", "CreatedAt", "FromStaffId", "Review", "ToPlayerId" },
                values: new object[] { 1, new DateTime(2025, 2, 6, 11, 29, 16, 866, DateTimeKind.Utc).AddTicks(8557), null, "Un meci foarte bun!", null });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "GameDate",
                value: new DateTime(2025, 2, 6, 11, 29, 16, 866, DateTimeKind.Utc).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 6, 11, 29, 16, 866, DateTimeKind.Utc).AddTicks(8516));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateReservation",
                value: new DateTime(2025, 2, 6, 11, 29, 16, 866, DateTimeKind.Utc).AddTicks(8441));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 6, 11, 29, 16, 866, DateTimeKind.Utc).AddTicks(8315));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 6, 11, 29, 16, 866, DateTimeKind.Utc).AddTicks(8322));

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_FromStaffId",
                table: "Feedback",
                column: "FromStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_ToPlayerId",
                table: "Feedback",
                column: "ToPlayerId");
        }
    }
}
