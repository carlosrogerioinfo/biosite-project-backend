using Biosite.Core.Commands;
using Biosite.Core.Enums;
using System;

namespace Biosite.Domain.Commands.Response
{
    public class BiomarkerResponse : ICommandResult
    {
        public BiomarkerResponse()
        {

        }

        public BiomarkerResponse(Guid id, string name, string description, string unity, BodyImageType bodyImageType, string aboveImpact, string aboveBelow)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Unity = unity;
            this.BodyImageType = bodyImageType;
            this.AboveImpact = aboveImpact;
            this.BelowImpact = aboveBelow;
        }

        //Properties
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unity { get; set; }
        public BodyImageType BodyImageType { get; set; }
        public string AboveImpact { get; set; }
        public string BelowImpact { get; set; }
    }
}
