using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace Integrador.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column(TypeName = "INT")]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(9)")]
        public int Dni { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public Roles UserType { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        public bool Active { get; set; }

        public enum Roles
        {
            Administrator = 1,
            Consultant
        }
    }
    
}
