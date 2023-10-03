using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechOil.Migrations
{
    public partial class techOil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "job",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "DATE", nullable: false),
                    HoursWorked = table.Column<int>(type: "INT", nullable: false),
                    ValueTime = table.Column<decimal>(type: "DECIMAL(38,17)", nullable: false),
                    Cost = table.Column<decimal>(type: "DECIMAL(38,17)", nullable: false),
                    ProjectId = table.Column<int>(type: "INT", nullable: false),
                    ServiceId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job", x => x.JobId);
                });

            migrationBuilder.CreateTable(
                name: "project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Status = table.Column<int>(type: "INT", nullable: false),
                    Active = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "service",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    ValueTime = table.Column<decimal>(type: "DECIMAL(38,17)", nullable: false),
                    Active = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_service", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Dni = table.Column<string>(type: "VARCHAR(9)", nullable: false),
                    UserType = table.Column<int>(type: "INT", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Active = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "UserId", "Active", "Dni", "Email", "Name", "Password", "UserType" },
                values: new object[] { 1, true, "42323443", "admin@gmail.com", "Admin", "09981d27d4c20b3b0f9dd200df1a8983846de268092a376e1c300b1db24cb81e", 1 });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "UserId", "Active", "Dni", "Email", "Name", "Password", "UserType" },
                values: new object[] { 2, true, "141324324", "pruebausuario@gmail.com", "Prueba Usuario", "23afa0ecff4c3793135f373179c52bcf6ea1ecb9f6a726b59a279f8c07918a09", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "job");

            migrationBuilder.DropTable(
                name: "project");

            migrationBuilder.DropTable(
                name: "service");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
