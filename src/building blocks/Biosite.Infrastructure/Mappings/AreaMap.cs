using Biosite.Core.Constants;
using Biosite.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biosite.Infrastructure.Mappings
{
    public class AreaMap : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> entity)
        {

            //Entity
            entity.ToTable("homolog_biosite_area");
            entity.HasKey(x => x.Id);

            //Properties
            entity.Property(x => x.Name).IsRequired().HasMaxLength(255).HasColumnType(Constants.Varchar);
            entity.Property(x => x.Description).IsRequired().HasMaxLength(1000).HasColumnType(Constants.Varchar);

            //Ignore equivalent NotMapping
            entity.Ignore(x => x.Notifications);

            //Relationchip cardinality
        }

    }
}