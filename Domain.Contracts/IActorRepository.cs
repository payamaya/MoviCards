using Domain.Models.Entities;

namespace Domain.Contracts
{
    public interface IActorRepository
    {
        Task<Actor?> GetMovieAsync(Guid movieId , Guid id, bool trackChanges);
        Task<IEnumerable<Actor>> GetActorsAsync(Guid movieId, bool trackChanges);
/*        Task<bool> ActorsExistAsync(List<Guid> actorIds);*/
        Task CreateAsync(Actor actor);
        void Update(Actor actor);
        void Delete(Actor actor);
  
        /*   Task<bool> DirectorExistsAsync(Guid directorId);
Task<bool> ActorsExistAsync(List<Guid> actorIds);
Task<bool> GenresExistAsync(List<Guid> genreIds);*/
    }
}
