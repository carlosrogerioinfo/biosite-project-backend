using Biosite.Domain.Entities;
using Biosite.Domain.Repositories.Base;
using System.Threading.Tasks;

namespace Biosite.Domain.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> LoginUserAsync(string email, string password);
        Task<User> GetByEmailAsync(string email);
    }
}