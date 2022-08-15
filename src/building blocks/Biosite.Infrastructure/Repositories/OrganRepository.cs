using Biosite.Domain.Entities;
using Biosite.Domain.Repositories;
using Biosite.Infrastructure.Contexts;
using Biosite.Infrastructure.Repositories.Base;
using System.Threading.Tasks;

namespace Biosite.Infrastructure.Repositories
{
    public class OrganRepository : GenericRepository<Organ>, IOrganRepository
    {
        public OrganRepository(BiositeDataContext context): base (context)
        {
        }

        #region IMPLEMENTAÇÕES ADICIONAIS

        public async Task<Organ> GetByNameAsync(string name)
        {
            return await GetDataAsync(x => x.Name == name);
        }

        #endregion
    }

}
