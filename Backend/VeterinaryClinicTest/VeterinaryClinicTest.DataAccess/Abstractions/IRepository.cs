using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.DataAccess.Abstractions
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IList<T>> GetListAsync();

        IQueryable<T> GetQueryable();

        Task<T> GetAsync(int id);

        Task<T> GetAndEnsureExistAsync(int id);

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task SaveChangesAsync(CancellationToken token);
    }
}

