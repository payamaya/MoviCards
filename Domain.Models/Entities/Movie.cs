
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities
{
    public class Movie 
    {
        [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } //Remove the d since IdentityUser has a build in ID
      /*  [Required(ErrorMessage = "Actor name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]*/
        public string Title { get; set; }
        public int Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Description { get; set; }

        public Guid DirectorId { get; set; }
        public Director Director { get; set; }

        // Navigation properties for many-to-many relationships
        public ICollection<MovieActor> MovieActors { get; set; }
        public ICollection<MovieGenre> MovieGenres { get; set; }

   

    }
}
