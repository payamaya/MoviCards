
namespace Movies.Shared.DTOs
{
    public record MovieUpdateDTO
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public int Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Description { get; set; }
        public Guid DirectorId { get; set; }
        public List<Guid> ActorIds { get; set; }
        public List<Guid> GenreIds { get; set; }
    }
}


