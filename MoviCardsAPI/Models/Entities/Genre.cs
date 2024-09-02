using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCardsAPI.Models.Entities
{
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }

        // Navigation property for the many-to-many relationship with Movies
        /*public ICollection<Movie> Movies { get; set; }= new List<Movie>();*/

        // Navigation property for the join table
        public ICollection<MovieGenre>? MovieGenres { get; set; }


    }
}
