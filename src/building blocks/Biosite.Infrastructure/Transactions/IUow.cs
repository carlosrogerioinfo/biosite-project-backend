using System.Threading.Tasks;

namespace Biosite.Infrastructure.Transactions
{
    public interface IUow
    {
        Task CommitAsync();
        void Commit();
        void Rollback();
    }
}
