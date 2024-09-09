using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Entities;
using Domain.Contracts;

namespace MovieCardsAPI.Controllers
{
    [Route("api/movies/{movieId}/actors")]
    [ApiController]

    public class ActorsController : ControllerBase
    {
        //private readonly MovieCardsContext _context;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ActorsController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        // GET: api/Actors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActors(Guid movieId)
        {
            var movieExists = await _uow.Actor.GetActorsAsync( movieId, false);

            if (movieExists is null) return NotFound($"Movie with ID {movieId} not found.");

            var actors = await _uow.Actor.GetMovieAsync(movieId, false);
            var actorDTOs = _mapper.Map<IEnumerable<Actor>>(actors);

            return Ok(actorDTOs);
        }

        // GET: api/Actors/5
   /*     [HttpGet("{id}")]
        public async Task<ActionResult<Actor>> GetActor(Guid id)
        {
            var actor = await _context.Actors.FindAsync(id);

            if (actor == null)
            {
                return NotFound();
            }

            return actor;
        }*/

        // PUT: api/Actors/5
/*        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActor(Guid id, Actor actor)
        {
            if (id != actor.Id)
            {
                return BadRequest();
            }

            _context.Entry(actor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActorExists(id))
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

        // POST: api/Actors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Actor>> PostActor(Actor actor)
        {
            _context.Actors.Add(actor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActor", new { id = actor.Id }, actor);
        }

        // DELETE: api/Actors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(Guid id)
        {
            var actor = await _context.Actors.FindAsync(id);
            if (actor == null)
            {
                return NotFound();
            }

            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActorExists(Guid id)
        {
            return _context.Actors.Any(e => e.Id == id);
        }*/
    }
}
