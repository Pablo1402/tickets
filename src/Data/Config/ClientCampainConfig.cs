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
    public class ClientCampainConfig : IEntityTypeConfiguration<ClientCampain>
    {
        public void Configure(EntityTypeBuilder<ClientCampain> builder)
        {
            builder.ToTable("ClientCampains");

            builder.HasKey(t => t.Id);

            builder.HasOne(x => x.Campain)
              .WithMany(x => x.ClientCampains)
              .HasForeignKey(x => x.CampainId)
              .HasPrincipalKey(x => x.Id)
              .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Client)
              .WithMany(x => x.ClientCampains)
              .HasForeignKey(x => x.ClientId)
              .HasPrincipalKey(x => x.Id)
              .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Tickets)
                .WithOne(x => x.ClientCampain)
                .HasForeignKey(x => x.ClientCampainId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
