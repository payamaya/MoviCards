namespace MoviCardsAPI.Models.Entities
{
    public class Director
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        // Foreign key property for ContactInformation is removed
        public int ContactInformationId { get; set; }
        public ContactInformation ContactInformation { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
