using AutoMapper.QueryableExtensions;
using Domain.Contracts;
using MovieCardsAPI.Validations;
using Movies.Infrastructure.Repository;

namespace MovieCardsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    /* Swagger [Produces("application/json")] */
    public class MoviesController : ControllerBase
    {
        private readonly MovieCardsContext _context;
        /* private object mapper;*/
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public MoviesController(MovieCardsContext context, IMapper mapper, IMovieRepository movieRepository)
        {
            _context = context;
            _mapper = mapper;
            _movieRepository = movieRepository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

                // GET: api/movies
         [HttpGet]
         public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies(bool includeMovies)
         {
            /* IEnumerable<MovieDTO> movieDTOs = await _context.Movies.ProjectTo<MovieDTO>(_mapper.ConfigurationProvider).ToListAsync();*/
            /*       var movieDTOs = includeMovies ? _mapper.Map<IEnumerable<MovieDTO>>(await _context.Movies.Include(m => m.MovieActors).ToListAsync())
                                                 : _mapper.Map<IEnumerable<MovieDTO>>(await _context.Movies.ToListAsync());*/
            var movieDTOs = includeMovies ? _mapper.Map<IEnumerable<MovieDTO>>(await _movieRepository.GetMoviesAsync(trackChanges: false, includeMovies: true))
                                          : _mapper.Map<IEnumerable<MovieDTO>>(await _movieRepository.GetMoviesAsync(trackChanges: false));
            return Ok(movieDTOs);
         }

   

        [HttpGet("{title} Name = \"RouteByTitle\"")]
         public async Task<ActionResult<IEnumerable<MovieDetailsDTO>>> GetMoviesByTitle(string title)
                {
                    var moviesByTitle = await _context.Movies.ProjectTo<MovieDetailsDTO>(_mapper.ConfigurationProvider).ToListAsync();

                    if (!string.IsNullOrWhiteSpace(title))
                    {
                        moviesByTitle = moviesByTitle.Where(m => m.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
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
                        var moviesByGenre = await _context.Movies
                            .Where(m => m.MovieGenres.Any(mg => mg.Genre.Name.ToLower() == genre.ToLower()))
                            .ProjectTo<MovieDetailsDTO>(_mapper.ConfigurationProvider)
                            .ToListAsync();

                        return Ok(moviesByGenre);
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception and return a proper error response
                        return StatusCode(500, $"Internal server error: {ex.Message}");
                    }
                }

        [HttpGet("search", Name = "SearchMovies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<MovieDetailsDTO>>> GetMovies(
            Guid? id,
            string? title,
            string?genre, 
            DateTime? releaseDate, 
            int? rating, 
            string? sortBy="title",// Default sorting by title
            string? sortOrder= "asc" // Default sorting order is ascending
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
                var query = _context.Movies.AsQueryable();

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
                query= query.Where(m => m.MovieGenres.Any(mg => mg.Genre.Name.ToLower() == genre.ToLower()));   
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
                               ?query.OrderByDescending(m => m.Rating)
                               :query.OrderBy(m => m.Rating);
                           break; 
                   
                       case "releasDate":
                               query = isDescending
                               ?query.OrderByDescending(m =>m.ReleaseDate)
                               :query.OrderBy(m => m.ReleaseDate);
                           break;
                   
                       default:
                         //Fallback to tile soring if sortBy is not recognized
                         query = sortOrder?.ToLower()=="desc"
                             ? query.OrderByDescending(m => m.Title)
                             : query.OrderBy(m => m.Title);
                         
                        break;
                       }
                   }
                }
                
                var movies = await query.ProjectTo<MovieDetailsDTO>(_mapper.ConfigurationProvider).ToListAsync();

            return Ok(movies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");

            }
        }

        // PUT: api/movies/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateMovie(Guid id, MovieUpdateDTO dto)
        {
            if (id != dto.Id) return BadRequest("Invalid movie ID or data.");

            var movieFromDB = await _movieRepository.GetMovieAsync(id);

            if ((movieFromDB is null)) return NotFound($"Movie with ID {id} not found.");

            _mapper.Map(dto, movieFromDB);
            await _context.SaveChangesAsync();


            /*return NoContent();*/
            return Ok(_mapper.Map<MovieDTO>(movieFromDB));// For demo!
        }


        // POST: api/movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=21223754
        [HttpPost]
        public async Task<ActionResult<MovieDTO>> CreateMovie(Guid id, MovieCreateDTO dto)
        {
            /*
             If we remove [ApiController] 
             Then we should validate/manage manually by ourselves
             if(!ModelState.isValid)
             {
             return BadRequest();
             }
             
             */
             // Ensure that all referenced IDs are valid
    if (!await _context.Directors.AnyAsync(d => d.Id == dto.DirectorId) ||
        !await _context.Actors.AnyAsync(a => dto.ActorIds.Contains(a.Id)) ||
        !await _context.Genres.AnyAsync(g => dto.GenreIds.Contains(g.Id)))
    {
        return BadRequest("Invalid IDs provided.");
    }

            // Map from MovieCreateDTO to Movie entity
            var movie = _mapper.Map<Movie>(dto);

           /* _context.Movies.Add(movie);*/
           await _movieRepository.CreateAsync(movie);
            await _context.SaveChangesAsync();

            // Map the saved Movie entity to MovieDTO for the response
            var movieDTO = _mapper.Map<MovieDTO>(movie);

            return CreatedAtAction(nameof(Queryable), new { id = movieDTO.Id }, movieDTO);
        }
        // DELETE: api/movies/{id}
        [HttpDelete("{id:guid}")]
        /* SWAGGER 
          [ProducesResponseType(StatusCodes.Status204NoContent)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
        */
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            var movie = await _movieRepository.GetMovieAsync(id);

            if (movie == null)   return NotFound();
            

           /* _context.Movies.Remove(movie);*/
            _movieRepository.Delete(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        /*
                [HttpPatch("{id:guid")]
                public async Task<ActionResult> PtachMovies(Guid id)*/

        private bool MovieExists(Guid id) => _context.Movies.Any(m => m.Id == id);

        [HttpGet("{id:guid}/details")]
        public async Task<ActionResult<MovieDetailsDTO>> GetMovieDetails(Guid id)
        {
            var dto = await _mapper.ProjectTo<MovieDetailsDTO>(_context.Movies.Where(m => m.Id != id)).FirstOrDefaultAsync();
            if (dto == null) return NotFound();

            return Ok(dto);
        }
    }
}
