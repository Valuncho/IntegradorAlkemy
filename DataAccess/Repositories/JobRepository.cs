using Integrador.DataAccess;
using Integrador.Models;
using Microsoft.EntityFrameworkCore;
using TechOil.DataAccess.Repositories.Interfaces;

namespace TechOil.DataAccess.Repositories
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        public JobRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override async Task<bool> Update(Job updateJob)
        {
            var Job = await _context.Jobs.FirstOrDefaultAsync(x => x.JobId == updateJob.JobId);
            if (Job == null) { return false; }

            Job.Date = updateJob.Date;
            Job.HoursWorked = updateJob.HoursWorked;
            Job.ValueTime = updateJob.ValueTime;
            Job.Cost = updateJob.Cost;

            _context.Jobs.Update(Job);
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var job = await _context.Jobs.Where(x => x.JobId == id).FirstOrDefaultAsync();
            if (job != null)
            {
                _context.Jobs.Remove(job);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public override async Task<bool> Insert(Job newJob)
        {
            try
            {
                var jobExisting = await _context.Jobs.FirstOrDefaultAsync(x => x.JobId == newJob.JobId);

                if (jobExisting != null)
                {
                    return false;
                }

                _context.Jobs.Add(newJob);
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
