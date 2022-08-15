using Biosite.Domain.Entities;
using Biosite.Domain.Repositories.Base;
using System.Threading.Tasks;

namespace Biosite.Domain.Repositories
{
    public interface IBiomarkerRepository: IGenericRepository<Biomarker>
    {
        Task<Biomarker> GetByNameAsync(string name);
    }
}
