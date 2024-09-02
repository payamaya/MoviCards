/*namespace MovieCardsAPI.Models.DTOs
{
    public record MovieCreateDTO(
        string Title, 
        int Rating, 
        DateTime ReleaseDate,
        string Description,
        int DirectorId,
        List<int> ActorIds,
        List<int> GenreIds);
}

    *//* Make it record important
    public class MovieCreateDTO
    {
        public string Title { get; set; }
        public int Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public int DirectorId { get; set; }
        public List<int> ActorIds { get; set; }
        public List<int> GenreIds { get; set; }
    }
    */

namespace Movies.Shared.DTOs
{

    public record MovieCreateDTO:MovieManipulationDTO
    {
    }
}
