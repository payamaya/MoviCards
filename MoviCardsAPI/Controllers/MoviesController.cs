using Microsoft.AspNetCore.Mvc;
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
    public class MoviesController : ControllerBase
    {
        private readonly MovieCardsContext _context;

        public MoviesController(MovieCardsContext context)
        {
            _context = context;
        }

        // GET: api/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        // GET: api/movies/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
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
        [HttpPost]
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
                DirectorId = movieCreateDTO.DirectorId
            };

            // Add additional logic to handle ActorIds and GenreIds if needed

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
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
    }
}



/* public async Task<ActionResult> CreateFile(IFormFile file)
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
