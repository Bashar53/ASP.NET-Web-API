using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IBoss.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeSalary = table.Column<double>(type: "float", nullable: false),
                    SupervisorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAttendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPresent = table.Column<bool>(type: "bit", nullable: false),
                    IsAbsent = table.Column<bool>(type: "bit", nullable: false),
                    IsOffday = table.Column<bool>(type: "bit", nullable: false),
                    tblEmployeeEmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeAttendances_Employees_tblEmployeeEmployeeId",
                        column: x => x.tblEmployeeEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmployeeCode", "EmployeeName", "EmployeeSalary", "SupervisorId" },
                values: new object[,]
                {
                    { 502030, "EMP320", "Mehedi Hasan", 50000.0, 502036 },
                    { 502031, "EMP321", "Ashikur Rahman", 45000.0, 502036 },
                    { 502032, "EMP322", "Rakibul Islam", 52000.0, 502030 },
                    { 502033, "EMP323", "Hasan Abdullah", 46000.0, 502031 },
                    { 502034, "EMP324", "Akib Khan", 66000.0, 502032 },
                    { 502035, "EMP325", "Rasel Shikder", 53500.0, 502033 },
                    { 502036, "EMP326", "Selim Reja", 59000.0, 502035 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendances_tblEmployeeEmployeeId",
                table: "EmployeeAttendances",
                column: "tblEmployeeEmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAttendances");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
