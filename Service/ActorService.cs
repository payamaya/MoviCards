using Domain.Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ActorService : IActorService
    {
        private readonly IUnitOfWork _uow;

        public ActorService(IUnitOfWork uow)
        {
            _uow = uow;
        }
    }
}
