using Biosite.Domain.Entities;
using Biosite.Core.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biosite.Infrastructure.Mappings
{
    public class BiomarkerMap : IEntityTypeConfiguration<Biomarker>
    {
        public void Configure(EntityTypeBuilder<Biomarker> entity)
        {
            //Entity
            entity.ToTable("homolog_biosite_biomarker");
            entity.HasKey(x => x.Id);

            //Properties
            entity.Property(x => x.Name).IsRequired().HasMaxLength(255).HasColumnType(Constants.Varchar);
            entity.Property(x => x.Description).IsRequired().HasColumnType(Constants.Text);
            entity.Property(x => x.Unity).IsRequired().HasMaxLength(10).HasColumnType(Constants.Varchar);
            entity.Property(x => x.BodyImageType).IsRequired().HasColumnType(Constants.SmallInt);
            entity.Property(x => x.AboveImpact).IsRequired().HasColumnType(Constants.Text);
            entity.Property(x => x.BelowImpact).IsRequired().HasColumnType(Constants.Text);

            //Ignore equivalent NotMapping
            entity.Ignore(x => x.Notifications);
        }
    }
}