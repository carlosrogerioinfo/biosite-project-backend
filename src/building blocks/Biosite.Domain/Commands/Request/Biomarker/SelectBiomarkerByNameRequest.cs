using Biosite.Core.Commands;

namespace Biosite.Domain.Commands.Request.Biomarker
{
    public class SelectBiomarkerByNameRequest : ICommand
    {
        public string Name { get; set; }
    }
}
