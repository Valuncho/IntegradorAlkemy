﻿// <auto-generated />
using System;
using Integrador.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace TechOil.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Integrador.Models.Proyecto", b =>
                {
                    b.Property<int>("IdProyecto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProyecto"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("BIT");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("Estado")
                        .HasColumnType("INT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("IdProyecto");

                    b.ToTable("proyecto");
                });

            modelBuilder.Entity("Integrador.Models.Servicio", b =>
                {
                    b.Property<int>("IdServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdServicio"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("BIT");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<decimal>("ValorHora")
                        .HasColumnType("DECIMAL(38,17)");

                    b.HasKey("IdServicio");

                    b.ToTable("servicio");
                });

            modelBuilder.Entity("Integrador.Models.Trabajo", b =>
                {
                    b.Property<int>("IdTrabajo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTrabajo"), 1L, 1);

                    b.Property<int>("CantHoras")
                        .HasColumnType("INT");

                    b.Property<decimal>("Costo")
                        .HasColumnType("DECIMAL(38,17)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DATE");

                    b.Property<int>("IdProyecto")
                        .HasColumnType("INT");

                    b.Property<int>("IdServicio")
                        .HasColumnType("INT");

                    b.Property<decimal>("ValorHora")
                        .HasColumnType("DECIMAL(38,17)");

                    b.HasKey("IdTrabajo");

                    b.ToTable("trabajo");
                });

            modelBuilder.Entity("Integrador.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("BIT");

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("VARCHAR(9)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("Tipo")
                        .HasColumnType("INT");

                    b.HasKey("IdUsuario");

                    b.ToTable("usuario");

                    b.HasData(
                        new
                        {
                            IdUsuario = 1,
                            Activo = true,
                            Contrasenia = "12345",
                            Dni = "42323443",
                            Nombre = "Admin",
                            Tipo = 1
                        },
                        new
                        {
                            IdUsuario = 2,
                            Activo = true,
                            Contrasenia = "1234",
                            Dni = "141324324",
                            Nombre = "Prueba Usuario",
                            Tipo = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}