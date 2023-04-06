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
    public class TicketConfig : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Tickets");

            builder.HasKey(t => t.Id);

            builder.Property(x => x.Note)
           .IsRequired()
           .HasColumnType("varchar(4000)");

            builder.HasOne(x => x.User)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x => x.UserId)
                .HasPrincipalKey(x => x.Id);

            builder.HasOne(x => x.ClientCampain)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x => x.UserId)
                .HasPrincipalKey(x => x.Id);

        }
    }
}
