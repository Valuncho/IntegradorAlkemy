using Integrador.DataAccess;
using Integrador.Models;
using Microsoft.EntityFrameworkCore;
using TechOil.DataAccess.Repositories.Interfaces;

namespace TechOil.DataAccess.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {

        public ProjectRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<bool> Update(Project updateProject)
        {
            var Project = await _context.Project.FirstOrDefaultAsync(x => x.ProjectId == updateProject.ProjectId);
            if (Project == null) { return false; }

            Project.Name = updateProject.Name;
            Project.Address = updateProject.Address;
            Project.Status = updateProject.Status;
            Project.Active = updateProject.Active;
            _context.Project.Update(Project);
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var project = await _context.Project.Where(x => x.ProjectId == id).FirstOrDefaultAsync();
            if (project != null)
            {
                _context.Project.Remove(project);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public override async Task<bool> Insert(Project newproject)
        {
            try
            {
                var projectExisting = await _context.Project.FirstOrDefaultAsync(x => x.Name == newproject.Name);

                if (projectExisting != null)
                {
                    return false;
                }

                _context.Project.Add(newproject);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Project>> GetAllStateProjects(int status) => await _context.Set<Project>().Where(x => x.Status == status).ToListAsync();

    }
}
