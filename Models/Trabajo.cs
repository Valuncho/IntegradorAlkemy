using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Integrador.Models
{
    [Table("trabajo")]
    public class Trabajo
    {
        [Key]
        [Column(TypeName = "INT")]
        public int IdTrabajo { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime Fecha { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int CantHoras { get; set; }

        [Required]
        [Column(TypeName = "DOUBLE")]
        public double ValorHora { get; set; }

        [Required]
        [Column(TypeName = "DOUBLE")]
        public double Costo { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int IdProyecto { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int IdServicio { get; set; }

    }
}
