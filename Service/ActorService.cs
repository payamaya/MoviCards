using AutoMapper;
using Domain.Contracts;
using Movies.Shared.DTOs;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class ActorService : IActorService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ActorService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

      /*  public Task<ActorDTO> GetActorAsync(Guid id, bool trackChnages = false)
        {
            throw new NotImplementedException();
        }*/

        // Method to get actors for a specific movie
        public async Task<IEnumerable<ActorDTO>> GetActorsAsync(Guid movieId, bool trackChanges = false)
        {
            var movieExists = await _uow.Movie.GetMovieAsync(movieId,trackChanges);

            if (movieExists == null) return null!;

            var actors = await _uow.Actor.GetActorsAsync(movieId, trackChanges); // Pass movieId correctly
            return _mapper.Map<IEnumerable<ActorDTO>>(actors); // Map actors to ActorDTO
        }
    }
}
