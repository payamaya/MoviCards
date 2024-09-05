namespace Domain.Contracts
{
    public interface IUnitOfWork
    {
        IMovieRepository MovieRepository { get; }

        Task CompleteAsync();
    }
}