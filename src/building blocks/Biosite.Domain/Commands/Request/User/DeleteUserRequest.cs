using Biosite.Core.Commands;
using System;

namespace Biosite.Domain.Commands.Request.User
{
    public class DeleteUserRequest : ICommand
    {
        public Guid Id { get; set; }
    }
}
