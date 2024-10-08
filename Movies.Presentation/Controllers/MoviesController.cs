﻿
using Microsoft.AspNetCore.Mvc;
using Movies.Shared.DTOs;
using Service;

namespace MovieCardsAPI.Controllers;

[Route("api/movies")]
[ApiController]

/* Swagger [Produces("application/json")] */
public class MoviesController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public MoviesController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    // GET: api/movies
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies(bool includeMovies)
    {

        var movieDTOs = await _serviceManager.MovieService.GetMoviesAsync(includeMovies);
        return Ok(movieDTOs);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<MovieDTO>> GetMovie(Guid id)
    {
        var movieDto = await _serviceManager.MovieService.GetMovieAsync(id);


        return Ok(movieDto);
    }


    [HttpGet("{title} Name = \"GetMoviesByTitle\"")]
    public async Task<ActionResult<IEnumerable<MovieDetailsDTO>>> GetMoviesByTitle(string title)
    {
        /*     var moviesByTitle = await _context.Movies.ProjectTo<MovieDetailsDTO>(_mapper.ConfigurationProvider).ToListAsync();

             if (!string.IsNullOrWhiteSpace(title))
             {
                 moviesByTitle = moviesByTitle.Where(m => m.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
             }
             var movies = await _uow.Movie.GetMoviesAsync(trackChanges: false);
             var moviesByTitle = _mapper.Map<IEnumerable<MovieDetailsDTO>>(movies)
                 .Where(m => m.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                 .ToList();*/
        var moviesByTitle = await _serviceManager.MovieService.GetMoviesByTitleAsync(title, trackChanges: false);

        if (moviesByTitle == null || !moviesByTitle.Any())
        {
            return NotFound($"No movies found with the title '{title}'.");
        }

        return Ok(moviesByTitle);
    }



    [HttpGet("{genre} Name = \"RouteByGenre\"")]
    public async Task<ActionResult<IEnumerable<MovieDetailsDTO>>> GetMoviesByGenre(string genre)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(genre))
            {
                return BadRequest("Genre cannot be empty.");
            }

            // Filter the movies by genre before projecting to DTO
            /*       var moviesByGenre = await _context.Movies
                       .Where(m => m.MovieGenres.Any(mg => mg.Genre.Name.ToLower() == genre.ToLower()))
                       .ProjectTo<MovieDetailsDTO>(_mapper.ConfigurationProvider)
                       .ToListAsync();
                   var moviesByGenre = await _uow.Movie.GetMoviesByGenreAsync(genre);*/

            var moviesByGenre = await _serviceManager.MovieService.GetMoviesByGenreAsync(genre, trackChanges: false);

            if (moviesByGenre == null || !moviesByGenre.Any())
            {
                return NotFound($"No movies found for the genre '{genre}'.");
            }

            return Ok(moviesByGenre);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    /*  [HttpGet("search", Name = "SearchMovies")]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult<IEnumerable<MovieDetailsDTO>>> GetMovies(
          Guid? id,
          string? title,
          string? genre,
          DateTime? releaseDate,
          int? rating,
          string? sortBy = "title",// Default sorting by title
          string? sortOrder = "asc" // Default sorting order is ascending
          )
      {
          try
          {
              if (!SortOrderValidator.IsValidSortOrder(sortOrder))
              {
                  return BadRequest("Invalid sort order. Please Use 'asc' or 'desc'.");
              }
              var sortFields = SortOrderValidator.IsValidSortBy(sortBy)
                  ? sortBy.Split(',', StringSplitOptions.RemoveEmptyEntries)
                  : new[] { "title" };
              var isDescending = sortOrder?.ToLower() == "desc";
              //Fetch all movies
              // var query = _context.Movies.AsQueryable();  
              var query = await _uow.Movie.GetMoviesAsync(trackChanges: false);


              //Appply flters based on the provided parameters
              if (id.HasValue)
              {
                  query = query.Where(m => m.Id == id.Value);
              }

              if (!string.IsNullOrWhiteSpace(title))
              {
                  string lowerCaseTitle = title.ToLower();
                  query = query.Where(m => m.Title.ToLower().Contains(lowerCaseTitle));
              }

              if (!string.IsNullOrWhiteSpace(genre))
              {
                  query = query.Where(m => m.MovieGenres.Any(mg => mg.Genre.Name.ToLower() == genre.ToLower()));
              }

              if (releaseDate.HasValue)
              {
                  query = query.Where(m => m.ReleaseDate.Date == releaseDate.Value.Date);
              }

              if (rating.HasValue)
              {
                  query = query.Where(m => m.Rating == rating.Value);
              }
              if (!string.IsNullOrEmpty(sortBy))
              {

                  foreach (var field in sortFields)
                  {

                      switch (sortBy?.ToLower())
                      {
                          case "title":
                              query = isDescending
                                  ? query.OrderByDescending(m => m.Title)
                                  : query.OrderBy(m => m.Title);
                              break;

                          case "rating":
                              query = isDescending
                              ? query.OrderByDescending(m => m.Rating)
                              : query.OrderBy(m => m.Rating);
                              break;

                          case "releasDate":
                              query = isDescending
                              ? query.OrderByDescending(m => m.ReleaseDate)
                              : query.OrderBy(m => m.ReleaseDate);
                              break;

                          default:
                              //Fallback to tile soring if sortBy is not recognized
                              query = sortOrder?.ToLower() == "desc"
                                  ? query.OrderByDescending(m => m.Title)
                                  : query.OrderBy(m => m.Title);

                              break;
                      }
                  }
              }

              var movies = await query.ProjectTo<MovieDetailsDTO>(_mapper.ConfigurationProvider).ToListAsync();

              return Ok(movies);
              var moviesDetailsDTO = _mapper.Map<IEnumerable<MovieDetailsDTO>>(query);

              return Ok(moviesDetailsDTO);
          }
          catch (Exception ex)
          {
              return StatusCode(500, $"Internal server error: {ex.Message}");

          }
      }*/

    // PUT: api/movies/{id}
    /*   [HttpPut("{id:guid}")]
       public async Task<IActionResult> UpdateMovie(Guid id, MovieUpdateDTO dto)
       {
           if (id != dto.Id) return BadRequest("Invalid movie ID or data.");

           var existingMovie = await _uow.Movie.GetMovieAsync(id, trackChanges: true);

           if ((existingMovie is null)) return NotFound($"Movie with ID {id} not found.");

           _mapper.Map(dto, existingMovie);
           await _uow.CompleteAsync();


           return NoContent();
           return Ok(_mapper.Map<MovieDTO>(existingMovie));// For demo!
       }*/


    // POST: api/movies
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=21223754
    /*    [HttpPost]
        public async Task<ActionResult<MovieDTO>> CreateMovie(Guid id, MovieCreateDTO dto)
        {

            //If we remove[ApiController]
               //Then we should validate/ manage manually by ourselves
               if (!ModelState.isValid)
            {
                return BadRequest();
            }


            // Ensure that all referenced IDs are valid
            if (!await _context.Directors.AnyAsync(d => d.Id == dto.DirectorId) ||
                !await _context.Actors.AnyAsync(a => dto.ActorIds.Contains(a.Id)) ||
                !await _context.Genres.AnyAsync(g => dto.GenreIds.Contains(g.Id)))
                // Ensure that all referenced IDs are valid
                if (!await _uow.Movie.DirectorExistsAsync(dto.DirectorId) ||
                    !await _uow.Movie.ActorsExistAsync(dto.ActorIds) ||
                    !await _uow.Movie.GenresExistAsync(dto.GenreIds))
                {
                    return BadRequest("Invalid IDs provided.");
                }

            // Map from MovieCreateDTO to Movie entity
            var movie = _mapper.Map<Movie>(dto);


            _context.Movies.Add(movie);
            // Create the movie using the repository
            await _uow.Movie.CreateAsync(movie);
            // Save changes via Unit of Work
            await _uow.CompleteAsync();

            // Map the saved Movie entity to MovieDTO for the response
            var movieDTO = _mapper.Map<MovieDTO>(movie);

            return CreatedAtAction(nameof(GetMovies), new { id = movieDTO.Id }, movieDTO);
        }*/
    // DELETE: api/movies/{id}
    [HttpDelete("{id:guid}")]
   //SWAGGER
   //[ProducesResponseType(StatusCodes.Status204NoContent)]
   //[ProducesResponseType(StatusCodes.Status404NotFound)]

   public async Task<IActionResult> DeleteMovie(Guid id)
   {
       /*  var movie = await _uow.Movie.GetMovieAsync(id, trackChanges: true);
   
         if (movie == null) return NotFound();
   
   
         _context.Movies.Remove(movie);
         _uow.Movie.Delete(movie);
         await _uow.CompleteAsync();*/
       var movieExists = await _serviceManager.MovieService.DeleteMovieAsync(id);
       // If the movie doesn't exist, return a 404 Not Found response
       if (!movieExists)
       {
           return NotFound($"Movie with ID '{id}' not found.");
       }
   
   
       return NoContent();
   }

   
  /*  [HttpPatch("{id:guid")]
    public async Task<ActionResult> PtachMovies(Guid id)



      [HttpGet("{id:guid}/details")]
    public async Task<ActionResult<MovieDetailsDTO>> GetMovieDetails(Guid id)
    {
        var dto = await _mapper.ProjectTo<MovieDetailsDTO>(_context.Movies.Where(m => m.Id != id)).FirstOrDefaultAsync();
        var movie = await _uow.Movie.GetMovieAsync(id, trackChanges: true);

        if (movie == null) return NotFound();
        var movieDTO = _mapper.Map<MovieDetailsDTO>(movie);

        return Ok(movieDTO);
    }*/


}
