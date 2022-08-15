using Biosite.Core.Entities;
using Biosite.Core.Enums;
using FluentValidator;
using System;
using System.Collections.Generic;

namespace Biosite.Domain.Entities
{
    public class Biomarker : Entity
    {
        
        protected Biomarker() { }

        public Biomarker(Guid id, string name, string description, string unity, BodyImageType bodyImageType, double optimizedValuesMin, double optimizedValuesMax, string aboveImpact, string belowImpact)
        {
            if (id != Guid.Empty) this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Unity = unity;
            this.BodyImageType = bodyImageType;
            this.AboveImpact = aboveImpact;
            this.BelowImpact = belowImpact;

            //Validations for notifications events here
            new ValidationContract<Biomarker>(this)
                .IsRequired(x => x.Name, "Nome do biomarcador deve ser informado")
                .IsRequired(x => x.Description, "Descrição da doença deve ser informado")
                .IsRequired(x => x.AboveImpact, "Impactos do biomarcador acima deve ser informado")
                .IsRequired(x => x.BelowImpact, "Impactos do biomarcador abaixo deve ser informado")
                ;
        }

        //Properties
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Unity { get; private set; }
        public BodyImageType BodyImageType { get; private set; }
        public string AboveImpact { get; private set; }
        public string BelowImpact { get; private set; }

        //Relationship

        //ManyToMany
        public ICollection<Organ> Organs { get; } = new List<Organ>();
    }
}
