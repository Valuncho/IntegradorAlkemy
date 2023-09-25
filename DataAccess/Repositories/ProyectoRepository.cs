using Integrador.DataAccess;
using Integrador.Models;
using Microsoft.EntityFrameworkCore;
using TechOil.DataAccess.Repositories.Interfaces;

namespace TechOil.DataAccess.Repositories
{
    public class ProyectoRepository : Repository<Proyecto>, IProyectoRepository
    {

        public ProyectoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<bool> Update(Proyecto updateProyecto)
        {
            var Proyecto = await _context.Proyecto.FirstOrDefaultAsync(x => x.IdProyecto == updateProyecto.IdProyecto);
            if (Proyecto == null) { return false; }

            Proyecto.Nombre = updateProyecto.Nombre;
            Proyecto.Direccion = updateProyecto.Direccion;
            Proyecto.Estado = updateProyecto.Estado;
            Proyecto.Activo = updateProyecto.Activo;
            _context.Proyecto.Update(Proyecto);
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var Proyecto = await _context.Proyecto.Where(x => x.IdProyecto == id).FirstOrDefaultAsync();
            if (Proyecto != null)
            {
                _context.Proyecto.Remove(Proyecto);
            }

            return true;
        }
    }
}
