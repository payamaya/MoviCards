using Microsoft.EntityFrameworkCore;
using Domain.Contracts;
using Domain.Models.Entities;

namespace Movies.Infrastructure.Repository
{
    public class ActorRepository : RepositoryBase<Actor>, IActorRepository
    {
       /* private readonly DbContext _context;*/

        public ActorRepository(MovieCardsContext context):base(context) { }

        public async Task<Actor?> GetMovieAsync(Guid movieId, Guid id, bool trackChanges)
        {
           return await FindByCondition(a => a.MovieId.Equals(movieId) && a.Id.Equals(id), trackChanges).FirstOrDefaultAsync();
        } 

        public async Task<IEnumerable<Actor>> GetActorsAsync(Guid movieId, bool trackChanges)
        {
            return await FindByCondition(a => a.MovieId.Equals(movieId), trackChanges).ToListAsync();
        }

    }
}
