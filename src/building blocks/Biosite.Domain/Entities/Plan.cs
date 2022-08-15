using Biosite.Core.Entities;
using FluentValidator;
using System;
using System.Collections.Generic;

namespace Biosite.Domain.Entities
{
    public class Plan : Entity
    {
        protected Plan() { } 

        public Plan(Guid id, string name, string description)
        {
            if (id != Guid.Empty) this.Id = id;
            this.Name = name;
            this.Description = description;

            //Validations for notifications events here
            new ValidationContract<Plan>(this)
                ;
        }

        //Properties
        public string Name { get; private set; }
        public string Description { get; private set; }

        //Relationchip

        //OneToMany
        public ICollection<User> Users { get; } = new List<User>();

        //ManyToMany
        public ICollection<Area> Areas { get; } = new List<Area>();
    }

}
