using Biosite.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Biosite.Infrastructure.Mappings
{
    public class PlanAreaMap : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> entity)
        {
            //Ignore equivalent NotMapping
            entity.Ignore(x => x.Notifications);

            //Many to Many
            entity
                .HasMany(a => a.Areas)
                .WithMany(la => la.Plans)
                .UsingEntity<Dictionary<string, object>>("homolog_biosite_plan_area",
                    x => x.HasOne<Area>().WithMany().HasForeignKey("AreaId"),
                    x => x.HasOne<Plan>().WithMany().HasForeignKey("PlanId")
                );


            ////Entity
            //entity.ToTable("homolog_biosite_plan_area");
            //entity.HasKey(x => new { x.PlanId, x.AreaId });

            ////Properties

            ////Ignore equivalent NotMapping
            //entity.Ignore(x => x.Notifications);

            ////Relationchip cardinality
            //entity
            //    .HasOne(am => am.Plan)
            //    .WithMany(a => a.PlanAreas)
            //    .HasForeignKey(am => am.PlanId);

            //entity
            //    .HasOne(am => am.Area)
            //    .WithMany(a => a.PlanAreas)
            //    .HasForeignKey(am => am.AreaId);
        }
    }
}
