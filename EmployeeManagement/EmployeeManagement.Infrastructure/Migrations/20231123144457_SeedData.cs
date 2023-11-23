using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Infrastructure.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5f4a571f-71cc-449e-84ef-68307f950eea"), "Accounteing" },
                    { new Guid("8e9a745e-73ce-45d3-a210-2e03c215d21e"), "Sales" },
                    { new Guid("910272de-4574-4f95-8601-8f5429a7f7b4"), "Director" },
                    { new Guid("a64f7b6b-0fe0-4e19-a38e-ff88dd855cc0"), "Support" },
                    { new Guid("bb6bdfa0-84ee-479c-9425-42b6d420180a"), "IT" },
                    { new Guid("c6b57c23-bd5e-4fc0-bd17-3f8d84ec5f80"), "Analyst" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5f4a571f-71cc-449e-84ef-68307f950eea"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8e9a745e-73ce-45d3-a210-2e03c215d21e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("910272de-4574-4f95-8601-8f5429a7f7b4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a64f7b6b-0fe0-4e19-a38e-ff88dd855cc0"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bb6bdfa0-84ee-479c-9425-42b6d420180a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c6b57c23-bd5e-4fc0-bd17-3f8d84ec5f80"));
        }
    }
}
