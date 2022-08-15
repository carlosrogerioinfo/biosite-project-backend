using Biosite.Domain.Entities;
using Biosite.Core.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biosite.Infrastructure.Mappings
{
    public class OrganMap : IEntityTypeConfiguration<Organ>
    {
        public void Configure(EntityTypeBuilder<Organ> entity)
        {
            //Entity
            entity.ToTable("homolog_biosite_organ");
            entity.HasKey(x => x.Id);

            //Properties
            entity.Property(x => x.Name).IsRequired().HasMaxLength(50).HasColumnType(Constants.Varchar);
            entity.Property(x => x.Description).IsRequired().HasMaxLength(500).HasColumnType(Constants.Varchar);
            entity.Property(x => x.Svg).IsRequired().HasMaxLength(250).HasColumnType(Constants.Varchar);

            //Ignore equivalent NotMapping
            entity.Ignore(x => x.Notifications);

            //Relationchip cardinality 1:N
            //entity.HasOne(x => x.Biomarker)
            //    .WithMany(x => x.Organs)
            //    .HasForeignKey(x => x.BiomarkerId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}