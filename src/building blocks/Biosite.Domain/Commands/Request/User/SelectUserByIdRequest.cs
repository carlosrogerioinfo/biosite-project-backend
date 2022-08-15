using Biosite.Core.Commands;
using System;

namespace Biosite.Domain.Commands.Request.User
{
    public class SelectUserByIdRequest : ICommand
    {
        public Guid Id { get; set; }
    }
}
