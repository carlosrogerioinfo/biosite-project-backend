using Biosite.Core.Commands;
using System;

namespace Biosite.Domain.Commands.Request.Biomarker
{
    public class DeleteBiomarkerRequest : ICommand
    {
        public Guid Id { get; set; }
    }
}
