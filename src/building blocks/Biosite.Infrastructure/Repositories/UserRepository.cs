using Biosite.Domain.Entities;
using Biosite.Domain.Repositories;
using Biosite.Infrastructure.Contexts;
using Biosite.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biosite.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(BiositeDataContext context) : base(context)
        {
        }

        #region IMPLEMENTAÇÕES ADICIONAIS

        public new async Task<User> GetByIdAsync(Guid id)
        {
            return await _dbSet
                .Include(p => p.Plan)
                .Include(p => p.Plan.Areas)
                .AsNoTrackingWithIdentityResolution()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public new async Task<IEnumerable<User>> GetAllAsync(int? skip = null, int? take = null)
        {
            return await _dbSet
                .Include(p => p.Plan)
                .Include(p => p.Plan.Areas)
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _dbSet
                .Include(p => p.Plan)
                .Include(p => p.Plan.Areas)
                .AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> LoginUserAsync(string email, string password)
        {
            return await _dbSet
                .Include(p => p.Plan)
                .Include(p => p.Plan.Areas)
                .AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(x => x.Email.Equals(email)
                    && x.Password.Equals(password));
        }

        #endregion
    }

}
