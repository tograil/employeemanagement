using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Infrastructure.Migrations
{
    public partial class ManagerNotNeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<Guid>(
                name: "ManagerId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("17a65533-756a-4959-a65e-e47b322aa08f"), "Director" },
                    { new Guid("33230b26-092e-41b8-a7f9-a9f2ab5a0296"), "IT" },
                    { new Guid("40822d9d-f06c-4f3f-b33e-d2d1427441ee"), "Sales" },
                    { new Guid("454438e1-cc71-4c44-a8b2-3f2a71046c55"), "Support" },
                    { new Guid("f81c3471-369a-4d2d-a9fc-d971e6f64879"), "Analyst" },
                    { new Guid("fa55484b-ce48-4124-965f-414ab2abde08"), "Accounteing" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("17a65533-756a-4959-a65e-e47b322aa08f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("33230b26-092e-41b8-a7f9-a9f2ab5a0296"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("40822d9d-f06c-4f3f-b33e-d2d1427441ee"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("454438e1-cc71-4c44-a8b2-3f2a71046c55"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f81c3471-369a-4d2d-a9fc-d971e6f64879"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fa55484b-ce48-4124-965f-414ab2abde08"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ManagerId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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
    }
}
