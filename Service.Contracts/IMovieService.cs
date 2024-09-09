
using Movies.Shared.DTOs;

namespace Service.Contracts
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDTO>> GetMoviesAsync(bool includeMovies, bool trackChanges = false) ;
    }
}
