using Microsoft.EntityFrameworkCore;
using Domain.Contracts;
using Domain.Models.Entities;
using Movies.Infrastructure.Data;

namespace Movies.Infrastructure.Repository
{
    public class ActorRepository : RepositoryBase<ApplicationUser>, IActorRepository
    {
       /* private readonly DbContext _context;*/

        public ActorRepository(MovieCardsContext context) :base(context) 
        { 
        }

        public async Task<ApplicationUser?> GetMovieAsync(Guid movieId, Guid id, bool trackChanges)
        {
           return await FindByCondition(a => a.MovieId.Equals(movieId) && a.Id.Equals(id), trackChanges).FirstOrDefaultAsync();
        } 

        public async Task<IEnumerable<ApplicationUser>> GetActorsAsync(Guid movieId, bool trackChanges)
        {
            return await FindByCondition(a => a.MovieId.Equals(movieId), trackChanges).ToListAsync();
        }

    }
}
