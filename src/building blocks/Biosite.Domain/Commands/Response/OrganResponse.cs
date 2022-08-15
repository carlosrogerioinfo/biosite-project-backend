using Biosite.Core.Commands;
using System;

namespace Biosite.Domain.Commands.Response
{
    public class OrganResponse : ICommandResult
    {
        public OrganResponse()
        {

        }

        public OrganResponse(Guid id, string name, string description, string svg)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Svg = svg;
        }

        //Properties
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Svg { get; set; }
    }
}
