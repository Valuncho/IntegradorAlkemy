using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Integrador.Models
{
    [Table("job")]
    public class Job
    {
        [Key]
        [Column(TypeName = "INT")]
        public int JobId { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime Date { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int HoursWorked { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL")]
        public double ValueTime { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL")]
        public double Cost { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int ProjectId { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int ServiceId { get; set; }

    }
}
