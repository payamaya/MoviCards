/*using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Ensure this is the correct namespace where MovieCardsContext is located
using MovieCardsAPI.Models.DTOs;
using MovieCardsAPI.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCardsAPI.Controllers
{
    [Route("api/movies")]
    [ApiController]

    *//*For Swagger*//*
    [Produces("application/json")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieCardsContext _context;

        public MoviesController(MovieCardsContext context)
        {
            _context = context;
        }

        // GET: api/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies()
        {
            var dto = _context.Movies*//*.Includes(m => m.Director)*//*.Select(m => new MovieDTO(m.Id, m.Title, m.Rating, m.ReleaseDate, m.Description, m.DirectorName));
            return Ok(await dto.ToListAsync());
        }

        // GET: api/movies/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDetailsDTO>> GetMovie(int id)
        {
            var dto = await _context.Movies
                .Where(m => m.Id == id)
                .Include(m => m.Director)
                .Include(m => m.MovieActors)
                    .ThenInclude(ma => ma.Actor)
                .Include(m => m.MovieGenres)
                    .ThenInclude(mg => mg.Genre)
                .Select(m => new MovieDetailsDTO(
                    m.Id,
                    m.Title,
                    m.Rating,
                    m.ReleaseDate,
                    m.Description,
                    m.Director.Name,
                    m.MovieActors.Select(ma => ma.Actor.Name).ToList(),
                    m.MovieGenres.Select(mg => mg.Genre.Name).ToList(),
                    m.Director.ContactInformation.Email,
                    m.Director.ContactInformation.PhoneNumber.ToString()
                ))
                .FirstOrDefaultAsync();

            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }


        // PUT: api/movies/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/movies
        *//*  [HttpPost]
          public async Task<IActionResult> CreateMovie([FromBody] MovieCreateDTO movieCreateDTO)
          {
              if (!ModelState.IsValid)
              {
                  return BadRequest(ModelState);
              }

              var movie = new Movie
              {
                  Title = movieCreateDTO.Title,
                  Rating = movieCreateDTO.Rating,
                  ReleaseDate = movieCreateDTO.ReleaseDate,
                  Description = movieCreateDTO.Description,
                  DirectorId = movieCreateDTO.DirectorId,
                  MovieActors = movieCreateDTO.ActorIds.Select(id => new MovieActor { ActorId = id }).ToList(),
                  MovieGenres = movieCreateDTO.GenreIds.Select(id => new MovieGenre { GenreId = id }).ToList()
              };

              // Add additional logic to handle ActorIds and GenreIds if needed

              _context.Movies.Add(movie);
              await _context.SaveChangesAsync();

           *//* 
            * FIX IMPORTANT
            * var movieDto = new MovieDTO(movie.Id,movie.Title,movie.Rating,movie.ReleaseDate);*//*

              return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
          }*//*




        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=21223754
        [HttpPost]

        public async Task<ActionResult<Movie>> PostMovie(MovieCreateDTO dto)
        {
            var movie = new Movie
            {
                Title = dto.Title,
                Rating = dto.Rating,
                ReleaseDate = dto.ReleaseDate,
                Description = dto.Description,
                DirectorId = dto.DirectorId,

  
            };

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            var movieDTO = new MovieDTO(
              movie.Id,movie.Title,
              movie.Rating,movie.ReleaseDate,
              movie.Description,movie.DirectorName
              );
            return CreatedAtAction(nameof(GetMovie), new { id = movieDTO.Id}, movieDTO);
        }




        // DELETE: api/movies/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
   

       *//* public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
        return await _context.Movies
            .Include(m => m.Director)
            .Include(m => m.MovieActors)
                .ThenInclude(ma => ma.Actor)
            .Include(m => m.MovieGenres)
                .ThenInclude(mg => mg.Genre)
            .ToListAsync();
        }*//*

    }
}



*//* public async Task<ActionResult> CreateFile(IFormFile file)
{
if(file.Length==0 || file.Length> 20971520 || file.ContentType != "application/pdf"){
  return BadRequest("No file or invalid one has been inputted");
}
var path = Path.Combine(
  Directory.GetCurrentDirectory(),
  $"uploaded_file_{Guid.NewGuid()}.pdf");
using (var stream= new FileStream(path,FileMode.Create))
{
  await file.CopyToAsync(stream); 
}
return Ok("Your file has been uploaded successfully");
}*/
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCardsAPI.Models.DTOs;
using MovieCardsAPI.Models.Entities;
using NuGet.Packaging;

namespace MovieCardsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieCardsContext _context;

        public MoviesController(MovieCardsContext context)
        {
            _context = context;
        }

        // GET: api/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies()
        {
            var movies = await _context.Movies
                .Include(m => m.Director)
                .Select(m => new MovieDTO(
                    m.Id,
                    m.Title,
                    m.Rating,
                    m.ReleaseDate,
                    m.Description))
                .ToListAsync();

            return Ok(movies);
        }

        // GET: api/movies/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetMovie(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.Director)
                .Where(m => m.Id == id)
                .Select(m => new MovieDTO(
                    m.Id,
                    m.Title,
                    m.Rating,
                    m.ReleaseDate,
                    m.Description
                    ))
                .FirstOrDefaultAsync();

            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        // GET: api/movies/{id}/details
        [HttpGet("{id}/details")]
        public async Task<ActionResult<MovieDetailsDTO>> GetMovieDetails(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.Director)
                    .ThenInclude(d => d.ContactInformation)
                .Include(m => m.MovieActors)
                    .ThenInclude(ma => ma.Actor)
                .Include(m => m.MovieGenres)
                    .ThenInclude(mg => mg.Genre)
                .Where(m => m.Id == id)
                .Select(m => new MovieDetailsDTO(
                    m.Id,
                    m.Title,
                    m.Rating,
                    m.ReleaseDate,
                    m.Description,
                    m.Director.Name,
                    m.MovieActors.Select(ma => ma.Actor.Name).ToList(),
                    m.MovieGenres.Select(mg => mg.Genre.Name).ToList(),
                    m.Director.ContactInformation.Email,
                    m.Director.ContactInformation.PhoneNumber.ToString()))
                .FirstOrDefaultAsync();

            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        // POST: api/movies
        [HttpPost]
        public async Task<ActionResult<MovieDTO>> CreateMovie(MovieCreateDTO dto)
        {
            var movie = new Movie
            {
                Title = dto.Title,
                Rating = dto.Rating,
                ReleaseDate = dto.ReleaseDate,
                Description = dto.Description,
                DirectorId = dto.DirectorId
            };

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, new MovieDTO(
                movie.Id,
                movie.Title,
                movie.Rating,
                movie.ReleaseDate,
                movie.Description));
        }

        // PUT: api/movies/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] MovieUpdateDTO dto)
        {
            if (id <= 0 || dto == null)
            {
                return BadRequest("Invalid movie ID or data.");
            }

            var movie = await _context.Movies
                .Include(m => m.MovieActors)
                    .ThenInclude(ma => ma.Actor)
                .Include(m => m.MovieGenres)
                    .ThenInclude(mg => mg.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound($"Movie with ID {id} not found.");
            }

            // Update the movie details
            movie.Title = dto.Title;
            movie.Rating = dto.Rating;
            movie.ReleaseDate = dto.ReleaseDate;
            movie.Description = dto.Description;
            movie.DirectorId = dto.DirectorId;

            // Update actors and genres associations
            movie.MovieActors.Clear();
            movie.MovieGenres.Clear();

            if (dto.ActorIds != null)
            {
                var actors = await _context.Actors.Where(a => dto.ActorIds.Contains(a.Id)).ToListAsync();
                foreach (var actor in actors)
                {
                    movie.MovieActors.Add(new MovieActor { MovieId = movie.Id, ActorId = actor.Id });
                }
            }

            if (dto.GenreIds != null)
            {
                var genres = await _context.Genres.Where(g => dto.GenreIds.Contains(g.Id)).ToListAsync();
                foreach (var genre in genres)
                {
                    movie.MovieGenres.Add(new MovieGenre { MovieId = movie.Id, GenreId = genre.Id });
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Log the exception and return an appropriate error response
                return StatusCode(500, "An error occurred while updating the movie.");
            }

            return NoContent();
        }


        // DELETE: api/movies/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id) => _context.Movies.Any(m => m.Id == id);
    }
}
