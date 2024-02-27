using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class SeedDataTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c9806d1d-87c1-420e-ba07-19668011f205", 0, "9d76b5d5-9dab-40d6-a3b0-ba39a7fff536", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEE0xcn37HDRSEYqktBnOq34UvgWjKzWjlSfwS3y3i9P6+YKdwRjgV77YqI1FEijjsA==", null, false, "aa23b3e7-27d1-41b7-84de-f3b85a18c249", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 27, 23, 12, 12, 35, DateTimeKind.Local).AddTicks(158), "Implement better styling for all public all public pages", "c9806d1d-87c1-420e-ba07-19668011f205", "Improve CSS styles" },
                    { 2, 1, new DateTime(2023, 9, 12, 23, 12, 12, 35, DateTimeKind.Local).AddTicks(195), "Create Android client app for the TaskBoard RESTFul API", "c9806d1d-87c1-420e-ba07-19668011f205", "Android Clien App" },
                    { 3, 2, new DateTime(2024, 1, 12, 23, 12, 12, 35, DateTimeKind.Local).AddTicks(201), "Create windows Forms desktop app client for the TaskBoard RESTfull API", "c9806d1d-87c1-420e-ba07-19668011f205", "Desktop Client App" },
                    { 4, 3, new DateTime(2023, 2, 12, 23, 12, 12, 35, DateTimeKind.Local).AddTicks(204), "Implement [Create Task] page for adding new tasks", "c9806d1d-87c1-420e-ba07-19668011f205", "Create Tasks" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c9806d1d-87c1-420e-ba07-19668011f205");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
