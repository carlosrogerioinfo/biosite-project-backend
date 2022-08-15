using Biosite.Core.Commands;
using System;

namespace Biosite.Domain.Commands.Request.Organ
{
    public class SelectOrganByIdRequest : ICommand
    {
        public Guid Id { get; set; }
    }
}
