using Integrador.Models;
using Microsoft.EntityFrameworkCore;
using TechOil.Helper;

namespace Integrador.DataAccess.DatabaseSeeding
{
    public class UserSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData
                (
                    new User
                    {
                        UserId = 1,
                        Name = "Admin",
                        Email = "admin@gmail.com",
                        Dni = 42323443,
                        UserType = User.Roles.Administrator,
                        Password = ContraseniaEncryptHelper.EncryptPassword("12345", "admin@gmail.com"),
                        Active = true
                    },
                    new User
                    {
                        UserId = 2,
                        Name = "Prueba Usuario",
                        Email = "pruebausuario@gmail.com",
                        Dni = 141324324,
                        UserType = User.Roles.Consultant,
                        Password = ContraseniaEncryptHelper.EncryptPassword("1234", "pruebausuario@gmail.com"),
                        Active = true
                    }
                );


        }
    }
}
