

using TechOil.DataAccess.Repositories;

namespace Integrador.Services
{
    
    public interface IUnitOfWork
    {
        public UserRepository UserRepository { get; }
        public JobRepository JobRepository { get; } 
        public ServiceRepository ServiceRepository { get; }
        public ProjectRepository ProjectRepository { get; }
        Task<int> Complete();

    }
}
