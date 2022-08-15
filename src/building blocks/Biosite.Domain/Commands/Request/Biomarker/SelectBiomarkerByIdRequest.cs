using Biosite.Core.Commands;
using System;

namespace Biosite.Domain.Commands.Request.Biomarker
{
    public class SelectBiomarkerByIdRequest : ICommand
    {
        public Guid Id { get; set; }
    }
}
