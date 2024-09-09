using Domain.Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _uow;

        public MovieService(IUnitOfWork uow)
        {
            _uow = uow;
        }
    }
}
