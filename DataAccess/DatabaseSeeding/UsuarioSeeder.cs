using Integrador.Models;
using Microsoft.EntityFrameworkCore;
using TechOil.Helper;

namespace Integrador.DataAccess.DatabaseSeeding
{
    public class UsuarioSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData
                (
                    new Usuario
                    {
                        IdUsuario = 1,
                        Nombre = "Admin",
                        Email = "admin123@gmail.com",
                        Dni = 42323443,
                        Tipo = (int)TipoUsuario.Admin,
                        Contrasenia = ContraseniaEncryptHelper.EncryptPassword("12345", "admin123@gmail.com"),
                        Activo = true
                    },
                    new Usuario
                    {
                        IdUsuario = 2,
                        Nombre = "Prueba Usuario",
                        Email = "pruebadeusuario@gmail.com",
                        Dni = 141324324,
                        Tipo = (int)TipoUsuario.Usuario,
                        Contrasenia = ContraseniaEncryptHelper.EncryptPassword("1234", "pruebadeusuario@gmail.com"),
                        Activo = true
                    }
                );


        }
    }
}
