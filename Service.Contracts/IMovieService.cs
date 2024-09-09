
using Movies.Shared.DTOs;

namespace Service.Contracts
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDTO>> GetMoviesAsync(bool includeMovies, bool trackChanges = false) ;

        Task<MovieDTO> GetMovieAsync(Guid id, bool trackChnages = false);
        // Add this method to fetch movies by title
        Task<IEnumerable<MovieDetailsDTO>> GetMoviesByTitleAsync(string title, bool trackChanges = false);
        Task<IEnumerable<MovieDetailsDTO>> GetMoviesByGenreAsync(string genre, bool trackChanges = false);
        Task<bool> DeleteMovieAsync(Guid id); // Should return bool indicating success or failure
    }
}
