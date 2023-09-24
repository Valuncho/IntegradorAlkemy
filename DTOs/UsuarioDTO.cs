namespace Integrador.DTOs
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public int Tipo { get; set; }
        public string Contrasenia { get; set; }
        public bool Activo { get; set; }
    }
}
