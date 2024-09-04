using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities
{
    public class MovieActor
    {
        [ForeignKey("MovieId")]
        public Movie? Movie { get; set; }
        public Guid MovieId { get; set; }

        [ForeignKey("ActorId")]
        public Actor? Actor { get; set; }
        public Guid ActorId { get; set; }
    }
}