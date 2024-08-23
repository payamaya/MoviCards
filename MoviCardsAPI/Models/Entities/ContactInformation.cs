namespace MoviCardsAPI.Models.Entities
{
    public class ContactInformation
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        // Foreign key property for Director is removed
        public int DirectorId { get; set; }
        public Director Director { get; set; }
    }
}
