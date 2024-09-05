using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
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

        public IMovieRepository MovieRepository { get; }

        public UnitOfWork(MovieCardsContext context)
        {
            MovieRepository = new MovieRepository(context);
            _context = context;
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
