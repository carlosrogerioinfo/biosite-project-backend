using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Biosite.Domain.Repositories.Base
{
    public interface IGenericRepository<T> where T : class
    {
        #region GET ASYNC

        Task<IEnumerable<T>> GetAllAsync(int? skip = null, int? take = null);
        
        Task<T> GetByIdAsync(Guid id);
        
        Task<T> GetByIdAsync(int id);

        Task<T> GetDataAsync(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        
        Task<IEnumerable<T>> GetListDataAsync(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int? skip = null, int? take = null);

        #endregion

        #region ADD/UPDATE/DELETE

        Task AddAsync(T entity);
        void Update(T entity);
        Task UpdateAsync(T entity, bool modifySingleEntity = false);
        void Delete(T entity);

        #endregion
    }
}
