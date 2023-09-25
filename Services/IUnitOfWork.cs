using TechOil.DataAccess.Repositories;

namespace Integrador.Services
{
    
    public interface IUnitOfWork
    {
        public UsuarioRepository UsuarioRepository { get; }
        Task<int> Complete();

    }
}
