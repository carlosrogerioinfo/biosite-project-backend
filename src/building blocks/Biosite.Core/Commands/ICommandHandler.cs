using System.Threading.Tasks;

namespace Biosite.Core.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}
