
namespace Movies.Shared.DTOs
{
    public record MovieManipulationDTO
    {
        public string Title { get; init; }
        public int Rating { get; init; }
        public DateTime ReleaseDate { get; init; }
        public string? Description { get; init; }
        public Guid DirectorId { get; init; }
        public List<Guid>? ActorIds { get; init; }
        public List<Guid>? GenreIds { get; init; }
    }
}


