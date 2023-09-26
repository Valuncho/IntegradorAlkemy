using Integrador.DataAccess;
using Integrador.Models;
using Microsoft.EntityFrameworkCore;
using TechOil.DataAccess.Repositories.Interfaces;

namespace TechOil.DataAccess.Repositories
{
    public class ServicioRepository : Repository<Servicio>, IServicioRepository
    {

        public ServicioRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<bool> Update(Servicio updateServicio)
        {
            var Servicio = await _context.Servicios.FirstOrDefaultAsync(x => x.IdServicio == updateServicio.IdServicio);
            if (Servicio == null) { return false; }

            Servicio.Descripcion = updateServicio.Descripcion;
            Servicio.ValorHora = updateServicio.ValorHora;
            Servicio.Activo = updateServicio.Activo;
            _context.Servicios.Update(Servicio);
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var Servicio = await _context.Servicios.Where(x => x.IdServicio == id).FirstOrDefaultAsync();
            if (Servicio != null)
            {
                _context.Servicios.Remove(Servicio);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public override async Task<bool> Insert(Servicio nuevoServicio)
        {
            try
            {
                var servicioExistente = await _context.Servicios.FirstOrDefaultAsync(x => x.IdServicio == nuevoServicio.IdServicio);

                if (servicioExistente != null)
                {
                    return false;
                }

                _context.Servicios.Add(nuevoServicio);
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
