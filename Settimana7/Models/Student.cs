using System.ComponentModel.DataAnnotations;

namespace Settimana7.Models
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Nome { get; set; }
        
        [Required]
        [StringLength(50)]
        public required string Cognome { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

    }
}
