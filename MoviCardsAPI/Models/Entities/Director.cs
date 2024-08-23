namespace MoviCardsAPI.Models.Entities
{
    public class Director
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        /*Relationships:
         * One-to-One With ContactInformation
         */
        // Reference Foriegn_Key F_K
        public int ContactInformationId { get; set; }
        public ContactInformation ContactInformation { get; set; }

        public ICollection<Movie> Movies{ get; set; }
    }
}
