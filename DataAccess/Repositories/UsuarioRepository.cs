using Integrador.DataAccess;
using Integrador.Models;
using TechOil.DataAccess.Repositories.Interfaces;
using Integrador.DTOs;
using Microsoft.EntityFrameworkCore;

namespace TechOil.DataAccess.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        
        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override async Task<bool> Update(Usuario updateUsuario)
        {
            var Usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == updateUsuario.IdUsuario);
            if (Usuario == null) { return false; }

            Usuario.Nombre = updateUsuario.Nombre;
            Usuario.Dni = updateUsuario.Dni;
            Usuario.Activo = updateUsuario.Activo;
            Usuario.Contrasenia = updateUsuario.Contrasenia;

            _context.Usuarios.Update(Usuario);
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var usuario = await _context.Usuarios.Where(x => x.IdUsuario == id).FirstOrDefaultAsync();
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            return true;
        }
        public override async Task<bool> Insert(Usuario nuevoUsuario)
        {
            try
            {
                var usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(x => x.Nombre == nuevoUsuario.Nombre || x.Dni == nuevoUsuario.Dni);

                if (usuarioExistente != null)
                {
                    return false;
                }

                _context.Usuarios.Add(nuevoUsuario);
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
