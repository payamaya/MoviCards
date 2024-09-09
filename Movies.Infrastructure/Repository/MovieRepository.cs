using Domain.Contracts;
using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Movies.Infrastructure.Repository
{
    public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
    {

        public MovieRepository(MovieCardsContext context): base(context) { }

        public Task<bool> ActorsExistAsync(List<Guid> actorIds)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DirectorExistsAsync(Guid directorId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GenresExistAsync(List<Guid> genreIds)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetActorsAsync(Guid movieId, bool v)
        {
            throw new NotImplementedException();
        }

        public async Task<Movie?> GetMovieAsync(Guid id, bool trackChanges)
        {
            return await FindByCondition(m => m.Id.Equals(id),trackChanges)
                .FirstOrDefaultAsync();
                          
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync(bool trackChanges, bool includeMovies = false)
        {
            return includeMovies ? await FindAll(trackChanges).Include(m => m.MovieActors).ToListAsync()
                                 : await FindAll(trackChanges).ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenreAsync(string genre)
        {
            // Convert genre to lowercase to perform a case-insensitive comparison
            var lowerGenre = genre.ToLower();

            return await Context.Movies
                .Where(m => m.MovieGenres.Any(mg => mg.Genre.Name.ToLower() == lowerGenre))
                .ToListAsync();
        }




        /*      // Check if the Director exists
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
              }*/
        /*  Implemented in base class
         *  public async Task CreateAsync(Movie movie)
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
   }*/

    }
}
