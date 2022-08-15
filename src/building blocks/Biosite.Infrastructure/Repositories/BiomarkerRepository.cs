using Biosite.Domain.Entities;
using Biosite.Domain.Repositories;
using Biosite.Infrastructure.Contexts;
using Biosite.Infrastructure.Repositories.Base;
using System.Threading.Tasks;

namespace Biosite.Infrastructure.Repositories
{
    public class BiomarkerRepository : GenericRepository<Biomarker>, IBiomarkerRepository
    {
        public BiomarkerRepository(BiositeDataContext context) : base (context)
        {
        }

        #region IMPLEMENTAÇÕES ADICIONAIS

        public async Task<Biomarker> GetByNameAsync(string name)
        {
            return await GetDataAsync(x => x.Name == name);
        }

        #endregion
    }

}
