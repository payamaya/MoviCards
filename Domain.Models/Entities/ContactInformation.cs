using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities
{
    public class ContactInformation
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        // Foreign Key for ApplicationUser (optional, depends on how you want the relationship)
        public Guid? DirectorId { get; set; }

        // Navigation property to link to a Director (one-to-one relationship)
        public Director? Director { get; set; }
    }
}
