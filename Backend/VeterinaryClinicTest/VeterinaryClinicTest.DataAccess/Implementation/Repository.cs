using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinicTest.Core.Exceptions;
using VeterinaryClinicTest.DataAccess.Abstractions;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.DataAccess.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IDBContext _context;
        private readonly DbSet<T> dbSet;
        public Repository(IDBContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }

        public virtual async Task DeleteAsync(T entity)
            => await Task.FromResult(dbSet.Remove(entity));

        public virtual async Task<T> GetAndEnsureExistAsync(int id)
        {
            var result = await dbSet.FindAsync(id);
            if (result == null)
                throw new ClinicExceptions(ErrorCode.GenericNotExist(typeof(T)));
            return result;
        }

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            dbSet.Where(expression).AsNoTracking();

        public virtual async Task<T> GetAsync(int id)
            => await dbSet.FindAsync(id);

        public virtual async Task<IList<T>> GetListAsync()
            => await dbSet.ToListAsync();


        public virtual IQueryable<T> GetQueryable()
            => dbSet.AsQueryable()
                    .AsNoTracking();
        

        public virtual async Task SaveChangesAsync(CancellationToken token)
        {
           if(await _context.SaveChangesAsync(token) < 0)
            {
                throw new Exception("Cannot save changes in db.");
            }
        }

        public virtual async Task UpdateAsync(T entity)
            => await Task.FromResult(dbSet.Update(entity));
    }
}

