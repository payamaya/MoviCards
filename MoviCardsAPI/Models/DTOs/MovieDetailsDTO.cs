namespace MovieCardsAPI.Models.DTOs
{
    public record MovieDetailsDTO(int Id, string Title, int Rating, DateTime ReleaseDate, string Description, string DirectorName, 
        List<string> ActorNames, List<string> GenreNames, string DirectorContactEmail, string DirectorContactPhone) : MovieDTO(Id, Title, Rating, ReleaseDate, Description, DirectorName);

    /*   public class MovieDetailsDTO : MovieDTO
        {
            public List<string> ActorNames { get; set; }
            public List<string> GenreNames { get; set; }
            public string DirectorContactEmail { get; set; }
            public string DirectorContactPhone { get; set; }
        }*/
}
