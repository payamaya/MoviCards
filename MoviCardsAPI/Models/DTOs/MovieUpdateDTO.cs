namespace MovieCardsAPI.Models.DTOs
{
    namespace MovieCardsAPI.Models.DTOs
    {
        public class MovieUpdateDTO
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int Rating { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string Description { get; set; }
            public int DirectorId { get; set; }
            public List<int> ActorIds { get; set; }
            public List<int> GenreIds { get; set; }
        }
    }

}
