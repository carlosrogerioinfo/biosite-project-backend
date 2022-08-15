using Biosite.Core.Commands;
using System.ComponentModel.DataAnnotations;

namespace Biosite.Domain.Commands.Request.User
{
    public class AuthenticateUserRequest : ICommand
    {
        [Required(ErrorMessage = "O e-mail é requerido")]
        public string Email { get; set; }
        [Required (ErrorMessage = "A senha é requerida")]
        public string Password { get; set; }
    }
}
