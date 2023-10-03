using Integrador.DataAccess.DatabaseSeeding;
using Integrador.Models;
using Microsoft.EntityFrameworkCore;

namespace Integrador.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Project> Project { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seeders = new List<IEntitySeeder>
            {
                new UserSeeder(),
            };


            foreach (var seeder in seeders)
            {
                seeder.SeedDatabase(modelBuilder);
            }
        }
        

    }
}
