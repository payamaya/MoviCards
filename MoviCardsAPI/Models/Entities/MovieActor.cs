using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCardsAPI.Models.Entities
{
    public class MovieActor
    {
        [ForeignKey("MovieId")]
        public Movie? Movie { get; set; }
        public int MovieId { get; set; }

        [ForeignKey("ActorId")]
        public Actor? Actor { get; set; }
        public int ActorId { get; set; }
    }
}