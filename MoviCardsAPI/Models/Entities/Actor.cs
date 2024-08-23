namespace MoviCardsAPI.Models.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
