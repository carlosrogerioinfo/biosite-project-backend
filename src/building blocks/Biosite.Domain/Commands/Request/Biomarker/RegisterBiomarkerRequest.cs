using Biosite.Core.Enums;
using Biosite.Core.Commands;

namespace Biosite.Domain.Commands.Request.Biomarker
{
    public class RegisterBiomarkerRequest : ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unity { get; set; }
        public BodyImageType BodyImageType { get; set; }
        public double OptimizedValuesMin { get; set; }
        public double OptimizedValuesMax { get; set; }
        public string AboveImpact { get; set; }
        public string BelowImpact { get; set; }
    }
}
