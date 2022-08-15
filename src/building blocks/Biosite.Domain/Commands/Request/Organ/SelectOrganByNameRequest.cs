using Biosite.Core.Commands;

namespace Biosite.Domain.Commands.Request.Organ
{
    public class SelectOrganByNameRequest : ICommand
    {
        public string Name { get; set; }
    }
}
