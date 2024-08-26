namespace MovieCardsAPI.Models.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property for the many-to-many relationship with Movies
        public ICollection<Movie> Movies { get; set; }

        // Navigation property for the join table
        public ICollection<MovieGenre> MovieGenres { get; set; }


    }
}
