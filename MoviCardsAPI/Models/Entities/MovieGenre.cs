using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCardsAPI.Models.Entities
{
    public class MovieGenre
    {
        [ForeignKey("MovieId")]
        public Movie? Movie { get; set; }
        public Guid MovieId { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
        public Guid GenreId { get; set; }
    }
}