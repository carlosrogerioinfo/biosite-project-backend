using System;

namespace Biosite.Core.Commands.Response
{
    public class AreaResponse : ICommandResult
    {
        public AreaResponse()
        {

        }

        public AreaResponse(Guid id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }

        //Properties
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
