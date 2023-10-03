using Integrador.DataAccess;
using Integrador.Models;
using TechOil.DataAccess.Repositories.Interfaces;
using Integrador.DTOs;
using Microsoft.EntityFrameworkCore;
using TechOil.DTOs;
using TechOil.Helper;

namespace TechOil.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override async Task<bool> Update(User updateUsuario)
        {
            var User = await _context.Users.FirstOrDefaultAsync(x => x.UserId == updateUsuario.UserId);
            if (User == null) { return false; }

            User.Name = updateUsuario.Name;
            User.Dni = updateUsuario.Dni;
            User.Active = updateUsuario.Active;
            User.Password = updateUsuario.Password;
            User.Email = updateUsuario.Email;

            _context.Users.Update(User);
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var user = await _context.Users.Where(x => x.UserId == id).FirstOrDefaultAsync();
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
        public override async Task<bool> Insert(User newUser)
        {
            try
            {
                var userExisting = await _context.Users.FirstOrDefaultAsync(x => x.Name == newUser.Name || x.Dni == newUser.Dni);

                if (userExisting != null)
                {
                    return false;
                }

                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<User?> AuthenticateCredentials(AutenticacionDTO dto)
        {
            return await _context.Users.SingleOrDefaultAsync
                (x => x.Email == dto.Email && x.Password == ContraseniaEncryptHelper.EncryptPassword(dto.Password, dto.Email));
        }


    }
}
