using Biosite.Core.Constants;
using Biosite.Core.Enums;
using Biosite.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Biosite.Infrastructure.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            //Entity
            entity.ToTable("homolog_biosite_user");
            entity.HasKey(x => x.Id);

            //Properties
            entity.Property(x => x.Name).IsRequired().HasMaxLength(50).HasColumnType(Constants.Varchar);
            entity.Property(x => x.Password).IsRequired().HasMaxLength(128).HasColumnType(Constants.Varchar);
            entity.Property(x => x.Email).IsRequired().HasMaxLength(160).HasColumnType(Constants.Varchar);
            entity.Property(x => x.Active).IsRequired().HasColumnType(Constants.Boolean);
            entity.Property(x => x.Weight).IsRequired().HasColumnType(Constants.Double);
            entity.Property(x => x.Height).IsRequired().HasColumnType(Constants.Double);

            entity.Property(x => x.Gender).IsFixedLength().HasMaxLength(1).IsUnicode(false).HasColumnType(Constants.Char)
                .HasConversion(x => x.ToString(), x => Enum.Parse<Gender>(x));

            entity.Property(x => x.Birthdate).IsRequired().HasColumnType(Constants.Datetime);
            entity.Property(x => x.IsPregnant).IsRequired().HasColumnType(Constants.Boolean);

            entity.Property(x => x.Verified).IsRequired().HasColumnType(Constants.Boolean);
            entity.Property(x => x.VerificationCode).HasMaxLength(5).HasColumnType(Constants.Varchar);
            entity.Property(x => x.ActivationCode).IsRequired().HasMaxLength(5).HasColumnType(Constants.Varchar);

            entity.Property(x => x.LastLoginDate).HasColumnType(Constants.Datetime);
            entity.Property(x => x.LastAuthorizationCodeRequest).HasColumnType(Constants.Datetime);

            //Ignore equivalent NotMapping
            entity.Ignore(x => x.Notifications);
        }
    }
}