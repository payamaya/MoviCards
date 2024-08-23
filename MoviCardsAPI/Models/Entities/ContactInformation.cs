namespace MoviCardsAPI.Models.Entities
{
    public class ContactInformation
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }


        // Reference Foriegn_Key F_K
        public int DirectorId { get; set; }
        public Director Director { get; set; }
    }
}
