using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Integrador.Models
{
    [Table("proyecto")]
    public class Proyecto
    {
        [Key]
        [Column(TypeName = "INT")]
        public int IdProyecto { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Direccion { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int Estado { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        public bool Activo { get; set; }

        // diccionario para saber el estado
        private static readonly Dictionary<int, string> Estados = new Dictionary<int, string>
        {
            { 1, "Pendiente" },
            { 2, "Confirmado" },
            { 3, "Terminado" },
        };
    }
}
