namespace TesteSNSYS.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> GetById(long id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Update(T entity);
        Task<T> Remove(T entity);
        void Dispose();
    }
}
