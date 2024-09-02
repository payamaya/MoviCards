using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCardsAPI.Models.Entities
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Description { get; set; }

        public Guid DirectorId { get; set; }
        public Director Director { get; set; }

        // Navigation properties for many-to-many relationships
        public ICollection<MovieActor> MovieActors { get; set; }
        public ICollection<MovieGenre> MovieGenres { get; set; }

        /*   // Constructor to ensure non-nullable properties are set
           public Movie(string title, string description, Director director)
           {
               Title = title ?? throw new ArgumentNullException(nameof(title));
               Description = description ?? throw new ArgumentNullException(nameof(description));
               Director = director ?? throw new ArgumentNullException(nameof(director));
               DirectorId = director.Id;
           }

           // Parameterless constructor with nullable properties for EF Core
              #nullable disable
               public Movie() { }
              #nullable enable*/


        // Parameterless constructor with default values
        /*  public Movie()
          {
           Title = string.Empty; // Or some other default value
           Description = string.Empty; // Or some other default value
           Director = new Director(); // Or some other default director or null if nullable
          }*/
    }
}
