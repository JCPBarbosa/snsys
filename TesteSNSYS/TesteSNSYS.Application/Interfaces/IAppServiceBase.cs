using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteSNSYS.Application.Interfaces
{
    public interface IAppServiceBase<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> GetById(long id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Update(T entity);
        Task<T> Remove(T entity);
        void Dispose();
    }
}
