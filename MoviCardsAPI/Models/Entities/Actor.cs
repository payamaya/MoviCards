using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace MovieCardsAPI.Models.Entities
{
    public class Actor
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }

        // Navigation property for the many-to-many relationship with Movies property for the join table
        public ICollection<MovieActor>? MovieActors { get; set; }= new List<MovieActor>();
    
    }
}