using Biosite.Core.Entities;
using System;

namespace Biosite.Domain.Entities
{
    public class BiomarkerPrescription : Entity
    {
        //Constructors
        protected BiomarkerPrescription() { } //EntityFramework needs empty constructor, for prevents corruptive, we sign constructor protected

        public BiomarkerPrescription(Guid id, Guid biomarkerId, Guid prescriptionId)
        {
            this.Id = id;
            this.BiomarkerId = biomarkerId;
            this.PrescriptionId = prescriptionId;

            //Validations for notifications events here

        }

        public BiomarkerPrescription(Guid biomarkerId, Guid prescriptionId)
        {
            this.BiomarkerId = biomarkerId;
            this.PrescriptionId = prescriptionId;

            //Validations for notifications events here
        }

        //Relationship
        public Guid BiomarkerId { get; set; }
        public virtual Biomarker Biomarker { get; set; }

        public Guid PrescriptionId { get; set; }
        public virtual Prescription Prescription { get; set; }

    }
}
