namespace MoviCardsAPI.Models.Entities
{
    public class ContactInformation
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        /* Relationships:
         * One-to-One with Director
         */
        /*  // Foreign Key for Director
          public int DirectorId { get; set; }
          public Director Director { get; set; }*/
        public Director Director { get; set; }
    }
}
