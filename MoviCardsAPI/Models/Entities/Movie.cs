using System.ComponentModel.DataAnnotations;

namespace MovieCardsAPI.Models.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }
        public DateTime ReleaseDate { get; set; }

        // Non-nullable property
        public int DirectorId { get; set; }
        public Director Director { get; set; } // Non-nullable

        public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
        public string DirectorName { get; internal set; }

        // Constructor to ensure non-nullable properties are set
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
           #nullable enable


        // Parameterless constructor with default values
        /*  public Movie()
          {
           Title = string.Empty; // Or some other default value
           Description = string.Empty; // Or some other default value
           Director = new Director(); // Or some other default director or null if nullable
          }*/
    }
}
