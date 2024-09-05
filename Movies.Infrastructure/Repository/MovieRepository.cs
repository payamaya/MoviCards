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
    }
}
