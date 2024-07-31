namespace movies_api.Interfaces;

public interface IUnitOfWork
{
    public IMovieRepository MovieRepository { get; }
    void Commit();
}

