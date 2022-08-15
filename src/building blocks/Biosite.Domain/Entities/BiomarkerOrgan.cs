using Biosite.Core.Entities;
using System;

namespace Biosite.Domain.Entities
{
    public class BiomarkerOrgan : Entity
    {
        //Constructors
        protected BiomarkerOrgan() { } //EntityFramework needs empty constructor, for prevents corruptive, we sign constructor protected

        public BiomarkerOrgan(Guid id, Guid biomarkerId, Guid organId)
        {
            this.Id = id;
            this.BiomarkerId = biomarkerId;
            this.OrganId = organId;

            //Validations for notifications events here

        }

        public BiomarkerOrgan(Guid biomarkerId, Guid organId)
        {
            this.BiomarkerId = biomarkerId;
            this.OrganId = organId;

            //Validations for notifications events here
        }

        //Relationship
        public Guid BiomarkerId { get; set; }
        public virtual Biomarker Biomarker { get; set; }

        public Guid OrganId { get; set; }
        public virtual Organ Organ { get; set; }
    }
}
