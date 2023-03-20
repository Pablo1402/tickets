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
    public class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Whatsapp)
                 .IsRequired()
                 .HasColumnType("varchar(20)");

            builder.HasOne(x => x.Store)
           .WithMany(x => x.Clients)
           .HasForeignKey(x => x.StoreId)
           .HasPrincipalKey(x => x.Id);

            builder.HasMany(x => x.ClientCampains)
                .WithOne(x => x.Client)
                .HasForeignKey(x => x.ClientId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.NoAction);
        } 
    }
}
