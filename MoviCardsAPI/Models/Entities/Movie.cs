namespace MoviCardsAPI.Models.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
        public string description { get; set; }

        /* 
         * Relationships:
         * One-to-Many with Director
         * Many-to-Many With Actor
         * Many-to-Many With Genre
         */
    }
}
