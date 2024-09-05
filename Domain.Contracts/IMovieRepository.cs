using Domain.Models.Entities;

namespace Domain.Contracts
{
    public interface IMovieRepository
    {
        Task<Movie?> GetMovieAsync(Guid id);
        Task<IEnumerable<Movie>> GetMoviesAsync(bool trackChanges = false, bool includeMovies = false);

        Task CreateAsync(Movie movie);
        void Update(Movie movie);

        void Delete(Movie movie);
    }
}