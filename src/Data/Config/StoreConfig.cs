using Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Config
{
    public class StoreConfig : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Stores");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                 .IsRequired()
                 .HasColumnType("varchar(200)");

            builder.Property(x => x.Email)
                 .IsRequired()
                 .HasColumnType("varchar(400)");

            builder.Property(x => x.Image)
                 .IsRequired()
                 .HasColumnType("varchar(100)");

            builder.Property(x => x.CreateDate)
               .IsRequired()
               .HasColumnType("datetime2");

            builder.HasOne(x => x.StorePlan)
                .WithMany(x => x.Stores)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.StorePlanId);

            builder.HasMany(x => x.Users)
                .WithOne(x => x.Store)
                .HasForeignKey(x => x.StoreId)
                .HasPrincipalKey(x => x.Id);

            builder.HasMany(x => x.Campains)
                .WithOne(x => x.Store)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.StoreId);

            builder.HasMany(x => x.Clients)
                .WithOne(x => x.Store)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.StoreId);

        }
    }
}
