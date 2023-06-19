namespace TesteSNSYS.Domain.Interfaces.Service
{
    public interface IServiceBase<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> GetById(long id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Update(T entity);
        Task<T> Remove(T entity);
        void Dispose();
    }
}
