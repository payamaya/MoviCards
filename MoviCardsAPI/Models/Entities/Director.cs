namespace MoviCardsAPI.Models.Entities
{
    public class Director
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        /* Relationships:
         * One-to-One with ContactInformation
         */
        // Foreign Key for ContactInformation
        public int ContactInformationId { get; set; }
        public ContactInformation ContactInformation { get; set; }

        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
