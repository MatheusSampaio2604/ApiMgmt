using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Interfaces
{
    public interface InterRepository<T> : IDisposable where T : class
    {
        Task<int> CreateAsync(T entity);
        Task<int> EditAsync(T entity);
        Task<T?> FindAsync(int id);
        Task<IEnumerable<T>> FindAllAsync();
        Task<bool> RemoveAsync(int id);
        Task<bool> RemoveAsync(T entity);
    }
}
