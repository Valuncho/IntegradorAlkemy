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
                name: "proyecto",
                columns: table => new
                {
                    IdProyecto = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Direccion = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Estado = table.Column<int>(type: "INT", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proyecto", x => x.IdProyecto);
                });

            migrationBuilder.CreateTable(
                name: "servicio",
                columns: table => new
                {
                    IdServicio = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    ValorHora = table.Column<decimal>(type: "DECIMAL(38,17)", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicio", x => x.IdServicio);
                });

            migrationBuilder.CreateTable(
                name: "trabajo",
                columns: table => new
                {
                    IdTrabajo = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "DATE", nullable: false),
                    CantHoras = table.Column<int>(type: "INT", nullable: false),
                    ValorHora = table.Column<decimal>(type: "DECIMAL(38,17)", nullable: false),
                    Costo = table.Column<decimal>(type: "DECIMAL(38,17)", nullable: false),
                    IdProyecto = table.Column<int>(type: "INT", nullable: false),
                    IdServicio = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trabajo", x => x.IdTrabajo);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Dni = table.Column<string>(type: "VARCHAR(9)", nullable: false),
                    Tipo = table.Column<int>(type: "INT", nullable: false),
                    Contrasenia = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.IdUsuario);
                });

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "IdUsuario", "Activo", "Contrasenia", "Dni", "Email", "Nombre", "Tipo" },
                values: new object[] { 1, true, "644219b532c740b851ae61412ecb2576cfb9d6a98a5fdba68cbde5f9a9661142", "42323443", "admin123@gmail.com", "Admin", 1 });

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "IdUsuario", "Activo", "Contrasenia", "Dni", "Email", "Nombre", "Tipo" },
                values: new object[] { 2, true, "cf1dbe457df8a129c3c764035499d6730341c127ff4d545ac79f75644a70d7be", "141324324", "pruebadeusuario@gmail.com", "Prueba Usuario", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "proyecto");

            migrationBuilder.DropTable(
                name: "servicio");

            migrationBuilder.DropTable(
                name: "trabajo");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
