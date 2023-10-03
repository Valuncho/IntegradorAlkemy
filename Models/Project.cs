using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Integrador.Models
{
    [Table("project")]
    public class Project
    {
        [Key]
        [Column(TypeName = "INT")]
        public int ProjectId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int Status { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        public bool Active { get; set; }

        // Diccionario para saber el estado
        private static readonly Dictionary<int, string> States = new Dictionary<int, string>
        {
        { 1, "Pending" },
        { 2, "Confirmed" },
        { 3, "Completed" },
        };
    }
}
