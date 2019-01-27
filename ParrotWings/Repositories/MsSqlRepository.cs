using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ParrotWings.Contexts;
using ParrotWings.Interfaces;

namespace ParrotWings.Repositories
{
    public class MsSqlRepository : IDbRepository
    {
        #region Fields

        private DbContext _dbContext;

        #endregion

        #region  Constructors

        public MsSqlRepository(/*DbContext dbContext*/)
        {
            //_dbContext = dbContext;
            _dbContext = new PwContext();
        }

        #endregion

        #region IDbRepository implementation

        #region Sync Methods

        public T Get<T>(params object[] keyValues) where T : class
        {
            return GetDbSet<T>().Find(keyValues);
        }

        public IEnumerable<T> GetAll<T>(bool noTracking = true) where T : class
        {
            var entityDbSet = GetDbSet<T>();

            return noTracking
                ? entityDbSet.AsNoTracking()
                : entityDbSet;
        }

        public T Add<T>(T entity) where T : class
        {
            return GetDbSet<T>().Add(entity);
        }

        public T Delete<T>(T entity) where T : class
        {
            return GetDbSet<T>().Remove(entity);
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public T Attach<T>(T entity) where T : class
        {
            return GetDbSet<T>().Attach(entity);
        }

        #endregion

        #region Async Methods

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return result;
        }

        public async Task<T> GetAsync<T>(CancellationToken cancellationToken = default(CancellationToken),
            params object[] keyValues) where T : class
        {
            var result = await GetDbSet<T>().FindAsync(cancellationToken, keyValues);

            return result;
        }

        #endregion

        #endregion

        #region Private Methods

        public DbSet<T> GetDbSet<T>() where T : class
        {
            return _dbContext.Set<T>();
        }

        #endregion
    }
}