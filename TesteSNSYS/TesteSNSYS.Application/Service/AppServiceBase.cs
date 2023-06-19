using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSNSYS.Application.Interfaces;
using TesteSNSYS.Domain.Interfaces.Service;

namespace TesteSNSYS.Application.Service
{
    public class AppServiceBase<T> : IDisposable, IAppServiceBase<T> where T : class
    {
        private readonly IServiceBase<T> _serviceBase;

        public AppServiceBase(IServiceBase<T> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public async Task<T> Add(T entity)
        {
            return await _serviceBase.Add(entity);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _serviceBase.GetAll();
        }

        public async Task<T> GetById(long id)
        {
            return await _serviceBase.GetById(id);
        }

        public async Task<T> Remove(T entity)
        {
            return await _serviceBase.Remove(entity);
        }

        public async Task<T> Update(T entity)
        {
            return await _serviceBase.Update(entity);
        }
    }
}
