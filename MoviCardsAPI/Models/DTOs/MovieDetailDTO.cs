namespace MovieCardsAPI.Models.DTOs
{
    public class MovieDetailDTO : MovieDTO
    {
        public List<string> ActorNames { get; set; }
        public List<string> GenreNames { get; set; }
        public string DirectorContactEmail { get; set; }
        public string DirectorContactPhone { get; set; }
    }
}
