using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSNSYS.Domain.Interfaces.Repositories;
using TesteSNSYS.Domain.Interfaces.Service;

namespace TesteSNSYS.Domain.Service
{
    public class ServiceBase<T> : IDisposable, IServiceBase<T> where T : class
    {
        private readonly IBaseRepository<T> _baseRepository;

        public ServiceBase(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<T> Add(T entity)
        {
            return await _baseRepository.Add(entity);
        }

        public void Dispose()
        {
            _baseRepository.Dispose();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _baseRepository.GetAll();
        }

        public async Task<T> GetById(long id)
        {
            return await _baseRepository.GetById(id);
        }

        public async Task<T> Remove(T entity)
        {
            return await _baseRepository.Remove(entity);
        }

        public async Task<T> Update(T entity)
        {
            return await _baseRepository.Update(entity);
        }
    }
}
