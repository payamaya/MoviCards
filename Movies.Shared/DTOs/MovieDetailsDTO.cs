
namespace Movies.Shared.DTOs
{
    public class MovieDetailsDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string DirectorName { get; set; }
        public List<string> ActorNames { get; set; }
        public List<string> GenreNames { get; set; }
        public string? DirectorContactEmail { get; set; }
        public string? DirectorContactPhone { get; set; }
    

        public MovieDetailsDTO() { }

        public MovieDetailsDTO(Guid id, string title, int rating, DateTime releaseDate, string description, string directorName, List<string> actorNames, List<string> genreNames, string directorContactEmail, string directorContactPhone)
        {
            Id = id;
            Title = title;
            Rating = rating;
            ReleaseDate = releaseDate;
            Description = description;
            DirectorName = directorName;
            ActorNames = actorNames;
            GenreNames = genreNames;
            DirectorContactEmail = directorContactEmail;
            DirectorContactPhone = directorContactPhone;
        }
    }
}


