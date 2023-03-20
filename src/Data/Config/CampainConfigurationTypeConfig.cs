using Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Config
{
    public class CampainConfigurationTypeConfig : IEntityTypeConfiguration<CampainConfigurationType>
    {
        public void Configure(EntityTypeBuilder<CampainConfigurationType> builder)
        {
            builder.ToTable("CampainConfigurationTypes");

            builder.HasKey(x => x.Id);


            builder.Property(x => x.Name)
                 .IsRequired()
                 .HasColumnType("varchar(50)");

            builder.HasMany(x => x.Campains)
                .WithOne(x => x.CampainConfigurationType)
                .HasForeignKey(x => x.CampainConfigurationTypeId)
                .HasPrincipalKey(x => x.Id);


        }
    }
}
