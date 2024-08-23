namespace MoviCardsAPI.Models.Entities
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

        // Foreign Key for Director
        public int DirectorId { get; set; }
        public Director Director { get; set; }

        public ICollection<Actor> Actors { get; set; } = new List<Actor>();
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    }
}
