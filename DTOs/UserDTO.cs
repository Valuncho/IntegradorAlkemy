namespace Integrador.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Dni { get; set; }
        public int UserType { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
    }
}
