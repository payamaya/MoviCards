using Domain.Models.Entities;

namespace Domain.Contracts
{
    public interface IMovieRepository
    {
        Task<Movie?> GetMovieAsync(Guid id);
        Task<IEnumerable<Movie>> GetMoviesAsync(bool includeMovies = false);
    }
}