using Movies.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IActorService
    {
   

     /*   Task<ActorDTO> GetActorAsync(Guid id,bool trackChnages = false);*/
        Task<IEnumerable<ActorDTO>> GetActorsAsync(Guid movieId, bool trackChnages = false);
    }
}
