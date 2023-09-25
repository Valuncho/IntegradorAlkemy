using Microsoft.EntityFrameworkCore;

namespace Integrador.DataAccess.DatabaseSeeding
{
    public interface IEntitySeeder
    {
        void SeedDatabase(ModelBuilder modelBuilder); 
    }
}
