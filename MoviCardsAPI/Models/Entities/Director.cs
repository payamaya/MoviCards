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
    }
}
