namespace MovieCardsAPI.Models.DTOs
{
    public record MovieUpdateDTO(string Title, double Rating, DateTime ReleaseDate, string Description, int DirectorId, List<int> ActorIds, List<int> GenreIds);
    /*
      public class MovieUpdateDTO
        {
            public string Title { get; set; }
            public double Rating { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string Description { get; set; }
            public int DirectorId { get; set; }
            public List<int> ActorIds { get; set; }
            public List<int> GenreIds { get; set; }
        }*/
}
