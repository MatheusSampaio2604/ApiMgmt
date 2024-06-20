using Infra.Context;
using Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Infra.Repository
{
    public class GeneralRepository<T> : InterRepository<T> where T : class
    {
        #region Private Element's
        private readonly DataContext _context;
        private readonly DbSet<T> _dbSet;
        #endregion

        #region Constructor
        public GeneralRepository(DataContext dataContext)
        {
            _context = dataContext;
            _dbSet = _context.Set<T>();
        }
        #endregion

        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose

        bool disposed = false;

        readonly SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
            }

            disposed = true;
        }
        #endregion

        #region Function's DB
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> CreateAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                return await SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao criar a solicitação!\n", e);
            }
        }

        public async Task<int> EditAsync(T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                return await SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw new Exception("Ocorreu um erro ao editar a solicitação!\n", e);
            }
        }

        public async Task<T?> FindAsync(int id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível executar essa busca!\n", e);
            }
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao efetuar essa busca!\n", e);
            }
        }

        public async Task<bool> RemoveAsync(int id)
        {
            try
            {
                T? entity = await _dbSet.FindAsync(id);
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                    return await SaveChangesAsync() != -1;
                }
                return false;
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao tentar executar essa tarefa!\n", e);
            }
        }

        public async Task<bool> RemoveAsync(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
                return await SaveChangesAsync() != -1;
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao tentar executar essa tarefa!\n", e);
            }
        }
        #endregion

    }
}
