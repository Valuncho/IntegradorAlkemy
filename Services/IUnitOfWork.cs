using TechOil.DataAccess.Repositories;

namespace Integrador.Services
{
    
    public interface IUnitOfWork
    {
        public UsuarioRepository UsuarioRepository { get; }
        public TrabajoRepository TrabajoRepository { get; } 
        public ServicioRepository ServicioRepository { get; }
        public ProyectoRepository ProyectoRepository { get; }
        Task<int> Complete();

    }
}
