using Integrador.DataAccess.DatabaseSeeding;
using Integrador.Models;
using Microsoft.EntityFrameworkCore;

namespace Integrador.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Trabajo> Trabajos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Proyecto> Proyecto { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seeders = new List<IEntitySeeder>
            {
                new UsuarioSeeder(),
            };


            foreach (var seeder in seeders)
            {
                seeder.SeedDatabase(modelBuilder);
            }
        }
        

    }
}
