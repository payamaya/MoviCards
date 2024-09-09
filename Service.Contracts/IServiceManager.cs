using Service.Contracts;

namespace Service
{
    public interface IServiceManager
    {
        IMovieService MovieService { get; }
        IActorService ActorService { get; }
    }
}