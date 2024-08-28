using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCardsAPI.Models.Entities
{
    public class Director
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        /* Relationships:
         * One-to-One with ContactInformation
         */
        // Foreign Key for ContactInformation
        [ForeignKey("ContactInformationId")]
        public ContactInformation? ContactInformation { get; set; }
        public int ContactInformationId { get; set; }

        public ICollection<Movie> Movies { get; set; } = new List<Movie>();

    }
    
}
