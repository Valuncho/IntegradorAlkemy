using Integrador.Models;
using Microsoft.EntityFrameworkCore;

namespace Integrador.DataAccess
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }


        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Trabajo> Trabajos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Proyecto> Proyecto { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

    }
}
