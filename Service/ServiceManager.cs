using Domain.Contracts;
using Service.Contracts;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IMovieService> _movieService;
        private readonly Lazy<IActorService> _actorService;


        /* public IMovieService MovieService { get { return _movieService.Value; } } */
        public IMovieService MovieService => _movieService.Value;

        public IActorService ActorService => _actorService.Value;

        public ServiceManager(IUnitOfWork uow)
        {
            if (uow is null)
            {
                throw new ArgumentNullException(nameof(uow));
            }

            _movieService = new Lazy<IMovieService>(() => new MovieService(uow));
            _actorService = new Lazy<IActorService>(() => new ActorService(uow));

        }
    }
}
