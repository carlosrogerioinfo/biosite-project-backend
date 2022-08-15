using Biosite.Domain.Entities;
using Biosite.Domain.Repositories.Base;
using System.Threading.Tasks;

namespace Biosite.Domain.Repositories
{
    public interface IOrganRepository: IGenericRepository<Organ>
    {
        Task<Organ> GetByNameAsync(string name);
    }
}
