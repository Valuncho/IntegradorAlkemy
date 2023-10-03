using static Integrador.Models.User;

namespace TechOil.DTOs
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public int Dni { get; set; }
        public Roles UserType { get; set; }
        public string Token { get; set; }
    }
}
