namespace MovieCardsAPI.Models.DTOs
{
    public record MovieDTO(int Id, string Title, int Rating, DateTime ReleaseDate, string Description, string DirectorName);

      /*
        public class MovieDTO
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int Rating { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string Description { get; set; }
            public string DirectorName { get; set; }
        }*/
}
