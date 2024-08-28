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

namespace MovieCardsAPI.Models.DTOs
{
  /*  public record MovieDTO(int Id, string Title, int Rating, DateTime ReleaseDate, string Description, string DirectorName);*/

/*    public record MovieDetailsDTO(
        int Id,
        string Title,
        int Rating,
        DateTime ReleaseDate,
        string Description,
        string DirectorName,
        List<string> ActorNames,
        List<string> GenreNames,
        string DirectorContactEmail,
        string DirectorContactPhone) : MovieDTO(Id, Title, Rating, ReleaseDate, Description, DirectorName);*/

    public record MovieCreateDTO(
        string Title,
        int Rating,
        DateTime ReleaseDate,
        string Description,
        int DirectorId,
        List<int> ActorIds,
        List<int> GenreIds);

   /* public record MovieUpdateDTO(
        string Title,
        int Rating,
        DateTime ReleaseDate,
        string Description,
        int DirectorId,
        List<int> ActorIds,
        List<int> GenreIds);*/
}
