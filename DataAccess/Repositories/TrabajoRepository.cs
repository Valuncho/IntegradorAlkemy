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
            var trabajo = await _context.Trabajos.FirstOrDefaultAsync(x => x.IdTrabajo == updateTrabajo.IdTrabajo);
            if (trabajo == null) { return false; }

            trabajo.Fecha = updateTrabajo.Fecha;
            trabajo.CantHoras = updateTrabajo.CantHoras;
            trabajo.ValorHora = updateTrabajo.ValorHora;
            trabajo.Costo = updateTrabajo.Costo;

            _context.Trabajos.Update(trabajo);
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var trabajo = await _context.Trabajos.Where(x => x.IdTrabajo == id).FirstOrDefaultAsync();
            if (trabajo != null)
            {
                _context.Trabajos.Remove(trabajo);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public override async Task<bool> Insert(Trabajo nuevoTrabajo)
        {
            try
            {
                var trabajoExistente = await _context.Trabajos.FirstOrDefaultAsync(x => x.IdTrabajo == nuevoTrabajo.IdTrabajo);

                if (trabajoExistente != null)
                {
                    return false;
                }

                _context.Trabajos.Add(nuevoTrabajo);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
