using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace Integrador.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        [Column(TypeName = "INT")]
        public int IdUsuario { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Email { get; set;}

        [Required]
        [Column(TypeName = "VARCHAR(9)")]
        public int Dni { get; set; }
        
        [Required]
        [Column(TypeName = "INT")]
        public int Tipo { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Contrasenia { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        public bool Activo { get; set; }
    }
    public enum TipoUsuario { Admin = 1, Usuario = 2 }
}
