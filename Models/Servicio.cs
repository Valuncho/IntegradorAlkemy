using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Integrador.Models
{
    [Table("servicio")]
    public class Servicio
    {
        [Key]
        [Column(TypeName = "INT")]
        public int IdServicio { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Descripcion { get; set; }

        [Required]
        [Column(TypeName = "DOBLE")]
        public double ValorHora { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        public bool Activo { get; set; }

        public void ActivarServicio()
        {
            Activo = true;
        }

        public void DesactivarServicio()
        {
            Activo = false;
        }
   
    }
}
