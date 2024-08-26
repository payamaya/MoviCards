using System.ComponentModel.DataAnnotations;

namespace MovieCardsAPI.Models.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        /* 
         * Relationships:
         * One-to-Many with Director
         * Many-to-Many With Actor
         * Many-to-Many With Genre
         */

        public int DirectorId { get; set; }
        public Director Director { get; set; }

        public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    }
}


