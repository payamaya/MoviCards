using Domain.Models.Entities;

namespace Movies.Infrastructure.Repository
{
    public interface IMovieRepository
    {
        Task<Movie?> GetMovieAsync(Guid id);
        Task<IEnumerable<Movie>> GetMoviesAsync(bool includeMovies = false);
    }
}