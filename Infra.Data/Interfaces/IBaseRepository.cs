namespace Infra.Data.Interfaces;

public interface IBaseRepository<T>: IDisposable where T: class
{
    void Add(T objeto);
    void Update(T objeto);
    T? GetById(int id);
    IList<T> GetAll();
    void Delete(int id);
}