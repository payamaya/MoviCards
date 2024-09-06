namespace Domain.Contracts
{
    public interface IUnitOfWork
    {
        IMovieRepository Movie { get; }

        IActorRepository Actor { get; }

        Task CompleteAsync();
    }
}