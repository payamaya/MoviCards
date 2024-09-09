using Service.Contracts;

namespace Service
{
    public interface IServiceManager
    {
        IActorService ActorService { get; }
        IMovieService MovieService { get; }
    }
}