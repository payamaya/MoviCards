using Domain.Models.Entities;

namespace Domain.Contracts
{
    public interface IActorRepository
    {
        Task<ApplicationUser?> GetMovieAsync(Guid movieId , Guid id, bool trackChanges);
        Task<IEnumerable<ApplicationUser>> GetActorsAsync(Guid movieId, bool trackChanges);
/*        Task<bool> ActorsExistAsync(List<Guid> actorIds);*/
        Task CreateAsync(ApplicationUser actor);
        void Update(ApplicationUser actor);
        void Delete(ApplicationUser actor);
  
        /*   Task<bool> DirectorExistsAsync(Guid directorId);
Task<bool> ActorsExistAsync(List<Guid> actorIds);
Task<bool> GenresExistAsync(List<Guid> genreIds);*/
    }
}
