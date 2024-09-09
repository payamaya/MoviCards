using AutoMapper;
using Domain.Contracts;
using Movies.Shared.DTOs;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MovieService :IMovieService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public MovieService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieDTO>> GetMoviesAsync(bool includeMovies, bool trackChanges = false)
        =>
            includeMovies ? _mapper.Map<IEnumerable<MovieDTO>>(await _uow.Movie.GetMoviesAsync(trackChanges, includeMovies))
                          : _mapper.Map<IEnumerable<MovieDTO>>(await _uow.Movie.GetMoviesAsync(trackChanges));
    }
}
