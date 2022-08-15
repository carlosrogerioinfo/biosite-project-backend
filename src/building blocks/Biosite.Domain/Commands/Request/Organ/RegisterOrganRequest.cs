using Biosite.Core.Commands;

namespace Biosite.Domain.Commands.Request.Organ
{
    public class RegisterOrganRequest : ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Svg { get; set; }
    }
}
