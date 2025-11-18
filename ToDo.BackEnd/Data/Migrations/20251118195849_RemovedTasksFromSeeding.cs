using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDo.BackEnd.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedTasksFromSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Complete", "CompletedAt", "Description", "PriorityId", "Title" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2025, 11, 18, 14, 56, 7, 867, DateTimeKind.Local).AddTicks(3596), "Sink is full.", 1, "Wash the dishes" },
                    { 2, false, null, "", 2, "Wash the floor" },
                    { 3, true, new DateTime(2025, 11, 18, 14, 56, 7, 867, DateTimeKind.Local).AddTicks(3645), "Sink is full.", 3, "Read" },
                    { 4, false, null, "Thinking french toast.", 1, "Prep for lunch" }
                });
        }
    }
}
