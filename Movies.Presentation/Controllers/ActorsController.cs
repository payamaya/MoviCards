using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Contracts;

namespace MovieCardsAPI.Controllers
{
    [Route("api/movies/{movieId}/actors")]
    [ApiController]

    public class ActorsController : ControllerBase
    {
        private readonly IServiceManager _seviceManager;


        public ActorsController(IServiceManager seviceManager)
        {
            _seviceManager = seviceManager;

        }

        // GET: api/Actors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActorDTO>>> GetActors(Guid movieId)
        {
            IEnumerable<ActorDTO> actorDTOs = await _seviceManager.ActorService.GetActorsAsync(movieId);
            return Ok(actorDTOs);
        }

        // GET: api/Actors/5
     /*   [HttpGet("{id:guid}")]
        public async Task<ActionResult<ActorDTO>> GetActor(Guid id)
        {
            var actorDto = await _seviceManager.ActorService.GetActorAsync(id);


            return Ok(actorDto);
        }
*/
        /*    // PUT: api/Actors/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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
            }
    */
        //[HttpPatch("{id:guid}")]
        //public async Task<ActionResult> PatchEmployee(Guid companyId, Guid id, JsonPatchDocument<EmployeeUpdateDto> patchDocument)
        //{
        //    if(patchDocument is null) return BadRequest("No patch doc");

        //    //var companyExists = await _db.Companies.AnyAsync(c => c.Id == companyId);

        //    //if(!companyExists) return NotFound();

        //    var employeeToPatch = await _uow.Employee.GetEmployeeAsync(companyId, id, true);
        //    if (employeeToPatch is null) return NotFound();


        //    var dto = _mapper.Map<EmployeeUpdateDto>(employeeToPatch);

        //    patchDocument.ApplyTo(dto, ModelState);
        //    TryValidateModel(dto);

        //    if (!ModelState.IsValid) return UnprocessableEntity(ModelState);

        //    _mapper.Map(dto, employeeToPatch);
        //    await _uow.CompleteAsync();

        //    return NoContent();
        //}
    }
}
