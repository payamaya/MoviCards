using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Movies.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieCardsContext _context;
        private readonly Lazy<IMovieRepository> _movieRepository;
        private readonly Lazy<IActorRepository> _actorRepository;

        public IMovieRepository Movie => _movieRepository.Value;
        public IActorRepository Actor => _actorRepository.Value;

        public UnitOfWork(MovieCardsContext context, Lazy<IMovieRepository> movieRepository, Lazy<IActorRepository> actorRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _movieRepository = movieRepository;
            _actorRepository= actorRepository;
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
