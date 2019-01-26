using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace ParrotWings.Interfaces
{
    public interface IDbRepository
    {
        T Get<T>(bool noTracking = true);
        IEnumerable<T> GetAll<T>(bool noTracking = true);
        T Add<T>(T entity);
        T Delete<T>(T entity);
    }
}