using System.Collections.Generic;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace ParrotWings.Interfaces
{
    public interface IDbRepository
    {
        #region Async methods

        Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<T> GetAsync<T>(CancellationToken cancellationToken = default(CancellationToken),
            params object[] keyValues) where T : class;

        #endregion

        #region Sync methods

        T Get<T>(params object[] keyValues) where T : class;
        IEnumerable<T> GetAll<T>(bool noTracking = true) where T : class;
        T Add<T>(T entity) where T : class;
        T Delete<T>(T entity) where T : class;
        T Attach<T>(T entity) where T : class;
        IEnumerable<T> ExecuteQuery<T>(string query, params object[] parameters);
        int Commit();
        DbContextTransaction BeginTransaction();

        #endregion
    }
}