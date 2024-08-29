using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCardsAPI.Models.Entities
{
    public class ContactInformation
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Email { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        public Guid DirectorId { get; set; } // Foreign key property

        // Navigation property
        public Director Director { get; set; }
    }
}
