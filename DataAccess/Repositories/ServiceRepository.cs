using Integrador.DataAccess;
using Integrador.Models;
using Microsoft.EntityFrameworkCore;
using TechOil.DataAccess.Repositories.Interfaces;

namespace TechOil.DataAccess.Repositories
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {

        public ServiceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<bool> Update(Service updateService)
        {
            var Service = await _context.Services.FirstOrDefaultAsync(x => x.ServiceId == updateService.ServiceId);
            if (Service == null) { return false; }

            Service.Description = updateService.Description;
            Service.ValueTime = updateService.ValueTime;
            Service.Active = updateService.Active;
            _context.Services.Update(Service);
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var service = await _context.Services.Where(x => x.ServiceId == id).FirstOrDefaultAsync();
            if (service != null)
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public override async Task<bool> Insert(Service newService)
        {
            try
            {
                var serviceExisting = await _context.Services.FirstOrDefaultAsync(x => x.ServiceId== newService.ServiceId);

                if (serviceExisting != null)
                {
                    return false;
                }

                _context.Services.Add(newService);
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
