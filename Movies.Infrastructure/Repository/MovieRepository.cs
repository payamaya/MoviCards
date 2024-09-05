using Domain.Contracts;
using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace Movies.Infrastructure.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieCardsContext _context;

        public MovieRepository(MovieCardsContext context)
        {
            _context = context;

        }


        public async Task<Movie?> GetMovieAsync(Guid id)
        {
            return await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync(bool trackChanges, bool includeMovies = false)
        {
            return includeMovies ? await _context.Movies.Include(m => m.MovieActors).ToListAsync()
                                 : await _context.Movies.ToListAsync();
        }

        public async Task CreateAsync(Movie movie)
        {
            await _context.AddAsync(movie);
        }

        public void Delete(Movie movie)
        {
           _context.Remove(movie);
        }

        public void Update(Movie movie)
        {
            _context.Update(movie);
        }

        // Check if the Director exists
        public async Task<bool> DirectorExistsAsync(Guid directorId)
        {
            return await _context.Directors.AnyAsync(d => d.Id == directorId);
        }

        // Check if all Actors exist
        public async Task<bool> ActorsExistAsync(List<Guid> actorIds)
        {
            var count = await _context.Actors.CountAsync(a => actorIds.Contains(a.Id));
            return count == actorIds.Count;  // Check if the count matches the number of actor IDs
        }

        // Check if all Genres exist
        public async Task<bool> GenresExistAsync(List<Guid> genreIds)
        {
            var count = await _context.Genres.CountAsync(g => genreIds.Contains(g.Id));
            return count == genreIds.Count;  // Check if the count matches the number of genre IDs
        }
        public async Task<bool> MovieExists(Guid id) 
        {
            return await _context.Movies.AnyAsync(m => m.Id == id);
        }
        public async Task<IEnumerable<Movie>> GetMoviesByGenreAsync(string genre)
        {
            return await _context.Movies
                .Where(m => m.MovieGenres.Any(mg => mg.Genre.Name.ToLower() == genre.ToLower()))
                .ToListAsync();
        }

    }
}
