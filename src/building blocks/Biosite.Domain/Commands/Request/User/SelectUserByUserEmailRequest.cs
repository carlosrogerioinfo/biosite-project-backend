using Biosite.Core.Commands;

namespace Biosite.Domain.Commands.Request.User
{
    public class SelectUserByUserEmailRequest : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
