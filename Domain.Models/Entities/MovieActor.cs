using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities
{
    public class MovieActor
    {

        public Guid MovieId { get; set; }  // MovieId is a Guid
        public string ActorId { get; set; }  // ActorId is a string to match ApplicationUser.Id

        public Movie Movie { get; set; }
        public ApplicationUser Actor { get; set; }
    }
}