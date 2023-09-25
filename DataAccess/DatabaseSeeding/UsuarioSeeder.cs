using Integrador.Models;
using Microsoft.EntityFrameworkCore;

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
                        Dni = 42323443,
                        Tipo = (int)TipoUsuario.Admin,
                        Contrasenia = "12345",
                        Activo = true
                    },
                    new Usuario
                    {
                        IdUsuario = 2,
                        Nombre = "Prueba Usuario",
                        Dni = 141324324,
                        Tipo = (int)TipoUsuario.Usuario,
                        Contrasenia = "1234",
                        Activo = true
                    }
                );


        }
    }
}
