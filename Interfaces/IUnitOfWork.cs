namespace movies_api.Interfaces;

public interface IUnitOfWork
{
    private IMovieRepository MovieRepository { get; }
    void Commit();
}

