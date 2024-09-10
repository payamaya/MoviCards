using AutoMapper;
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

        public ServiceManager(Lazy<IMovieService> movieService, Lazy<IActorService> actorService)
        {
            

            _movieService = movieService;
            _actorService = actorService;

        }
    }
}
 