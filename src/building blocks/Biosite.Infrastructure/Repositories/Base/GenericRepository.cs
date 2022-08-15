using Biosite.Domain.Repositories.Base;
using Biosite.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Biosite.Infrastructure.Repositories.Base
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DbSet<T> _dbSet;
        private BiositeDataContext _context;

        public GenericRepository(BiositeDataContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync(int? skip = null, int? take = null)
        {
            if (skip.HasValue & take.HasValue)
            {
                return await _dbSet
                    .AsNoTrackingWithIdentityResolution()
                    .Skip(take.Value * (skip.Value - 1))
                    .Take(take.Value)
                    .ToListAsync();
            }

            return await _dbSet
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetDataAsync(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            var query = _dbSet
                .AsQueryable()
                .AsNoTrackingWithIdentityResolution();

            if (expression != null)
                query = query.Where(expression);

            if (include != null)
                query = include(query);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetListDataAsync(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int? skip = null, int? take = null)
        {
            var query = _dbSet
                .AsQueryable()
                .AsNoTrackingWithIdentityResolution();

            if (expression != null)
                query = query.Where(expression);

            if (include != null)
                query = include(query);

            if (skip.HasValue && take.HasValue)
            {
                query = query.Skip(take.Value * (skip.Value - 1));
                query = query.Take(take.Value);
            }

            return await query.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task UpdateAsync(T entity, bool modifySingleEntity = false)
        {
            if (modifySingleEntity)
            {
                EntityEntry entityEntry = _context.Entry<T>(entity);
                entityEntry.State = EntityState.Modified;
            }
            else
            {
                await Task.FromResult(_dbSet.Update(entity));
            }
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}

