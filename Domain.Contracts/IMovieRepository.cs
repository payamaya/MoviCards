using Domain.Models.Entities;

namespace Domain.Contracts
{
    public interface IMovieRepository
    {
        Task<Movie?> GetMovieAsync(Guid id);
        Task<IEnumerable<Movie>> GetMoviesAsync(bool trackChanges = false, bool includeMovies = false);
        Task<IEnumerable<Movie>> GetMoviesByGenreAsync(string genre);

        Task CreateAsync(Movie movie);
        void Update(Movie movie);
        void Delete(Movie movie);

        // New validation method signatures:
        Task<bool> DirectorExistsAsync(Guid directorId);
        Task<bool> ActorsExistAsync(List<Guid> actorIds);
        Task<bool> GenresExistAsync(List<Guid> genreIds);
    }
}