using Biosite.Core.Entities;
using FluentValidator;
using System;
using System.Collections.Generic;

namespace Biosite.Domain.Entities
{
    public class Organ : Entity
    {
        protected Organ() { }

        public Organ(Guid id, string name, string description, string svg)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Svg = svg;

            //Validations for notifications events here
            new ValidationContract<Organ>(this)
                .IsRequired(x => x.Name, "Nome do órgão ou glândula deve ser informado")
                .IsRequired(x => x.Description, "Descrição do órgão ou glândula deve ser informado")
                .IsRequired(x => x.Svg, "Descrição do órgão ou glândula deve ser informado")
                ;
        }

        //Properties
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Svg { get; private set; }

        //Relationship
        public ICollection<Biomarker> Biomarkers { get; } = new List<Biomarker>();
    }
}
