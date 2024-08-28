namespace MovieCardsAPI.Models.DTOs
{
    public record MovieUpdateDTO(
        int id,
        string Title, 
        int Rating,
        DateTime ReleaseDate, 
        string Description, 
        int DirectorId, 
        List<int> ActorIds, 
        List<int> GenreIds);
}
