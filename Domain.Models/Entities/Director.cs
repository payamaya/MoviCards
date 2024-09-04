using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities
{
    public class Director
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Director name is requires field")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        /* Relationships:
         * One-to-One with ContactInformation
         */
        // Foreign Key for ContactInformation
        [ForeignKey("ContactInformationId")]
        public ContactInformation ContactInformation { get; set; }
        public Guid ContactInformationId { get; set; }

        public ICollection<Movie>? Movies { get; set; }

    }

}
