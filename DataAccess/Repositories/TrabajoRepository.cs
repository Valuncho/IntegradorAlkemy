using Integrador.DataAccess;
using Integrador.Models;
using Microsoft.EntityFrameworkCore;
using TechOil.DataAccess.Repositories.Interfaces;

namespace TechOil.DataAccess.Repositories
{
    public class TrabajoRepository : Repository<Trabajo>, ITrabajoRepository
    {

        public TrabajoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<bool> Update(Trabajo updateTrabajo)
        {
            var Trabajo = await _context.Trabajos.FirstOrDefaultAsync(x => x.IdTrabajo == updateTrabajo.IdTrabajo);
            if (Trabajo == null) { return false; }

            Trabajo.Fecha = updateTrabajo.Fecha;
            Trabajo.CantHoras = updateTrabajo.CantHoras;
            Trabajo.ValorHora = updateTrabajo.ValorHora;
            Trabajo.Costo = updateTrabajo.Costo;

            _context.Trabajos.Update(Trabajo);
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var Trabajo = await _context.Trabajos.Where(x => x.IdTrabajo == id).FirstOrDefaultAsync();
            if (Trabajo != null)
            {
                _context.Trabajos.Remove(Trabajo);
            }

            return true;
        }
    }
}
