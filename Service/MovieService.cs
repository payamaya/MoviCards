using AutoMapper;
using Domain.Contracts;
using Movies.Shared.DTOs;
using Service.Contracts;
namespace Service;

public class MovieService :IMovieService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public MovieService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public async Task<IEnumerable<MovieDTO>> GetMoviesAsync(bool includeMovies, bool trackChanges = false)
        =>
            includeMovies ? _mapper.Map<IEnumerable<MovieDTO>>(await _uow.Movie.GetMoviesAsync(trackChanges, includeMovies))
                          : _mapper.Map<IEnumerable<MovieDTO>>(await _uow.Movie.GetMoviesAsync(trackChanges));

        public async Task<MovieDTO> GetMovieAsync(Guid id, bool trackChnages = false)
        {
            var movie = await _uow.Movie.GetMovieAsync(id, trackChanges: false);

         /*   if (movie == null)
            {
               /// ToDo: Fix later return NotFound();
            }*/
            return _mapper.Map<MovieDTO>(movie);
        }
    // Implementation for getting movies by title
    public async Task<IEnumerable<MovieDetailsDTO>> GetMoviesByTitleAsync(string title, bool trackChanges = false)
    {
        var movies = await _uow.Movie.GetMoviesAsync(trackChanges);
        var filteredMovies = movies.Where(m => m.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
        return _mapper.Map<IEnumerable<MovieDetailsDTO>>(filteredMovies);
    }


    public async Task<IEnumerable<MovieDetailsDTO>> GetMoviesByGenreAsync(string genre, bool trackChanges = false)
    {
        var moviesByGenre = await _uow.Movie.GetMoviesByGenreAsync(genre);
        return _mapper.Map<IEnumerable<MovieDetailsDTO>>(moviesByGenre);
    }


    public async Task<bool> DeleteMovieAsync(Guid id)
    {
        var movie = await _uow.Movie.GetMovieAsync(id, trackChanges: true);

        if(movie == null)
        {
            return false;  
        }
        _uow.Movie.Delete(movie);
        await _uow.CompleteAsync();

        return true;
    }
}

