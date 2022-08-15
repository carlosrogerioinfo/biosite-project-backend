using System.Collections.Generic;

namespace Biosite.Core.Commands.Response
{
    public class PlanResponse : ICommandResult
    {
        public PlanResponse()
        {

        }

        public PlanResponse(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<AreaResponse> Areas { get; set; }
    }
}
