using Biosite.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Biosite.Infrastructure.Mappings
{
    public class BiomarkerOrganMap : IEntityTypeConfiguration<Biomarker>
    {
        public void Configure(EntityTypeBuilder<Biomarker> entity)
        {
            //Ignore equivalent NotMapping
            entity.Ignore(x => x.Notifications);

            //Many to Many
            entity
                .HasMany(a => a.Organs)
                .WithMany(la => la.Biomarkers)
                .UsingEntity<Dictionary<string, object>>("homolog_biosite_biomarker_organ",
                    x => x.HasOne<Organ>().WithMany().HasForeignKey("OrganId"),
                    x => x.HasOne<Biomarker>().WithMany().HasForeignKey("BiomarkerId")
                );
        }

    }
}