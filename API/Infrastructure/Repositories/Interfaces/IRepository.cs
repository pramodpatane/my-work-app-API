namespace API.Infrastructure.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
