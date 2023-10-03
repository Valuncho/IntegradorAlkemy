using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Integrador.Models
{
    [Table("service")]
    public class Service
    {
        [Key]
        [Column(TypeName = "INT")]
        public int ServiceId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL")]
        public double ValueTime { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        public bool Active { get; set; }

        public void ActivateService()
        {
            Active = true;
        }

        public void DeactivateService()
        {
            Active = false;
        }
    }
}   
