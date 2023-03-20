using Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Config
{
    public class CampainConfig : IEntityTypeConfiguration<Campain>
    {
        public void Configure(EntityTypeBuilder<Campain> builder)
        {
            builder.ToTable("Campain");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                 .IsRequired()
                 .HasColumnType("varchar(200)");

            builder.HasOne(x => x.Store)
                .WithMany(x => x.Campains)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.StoreId);

            builder.HasOne(X => X.CampainConfigurationType)
                .WithMany(x => x.Campains)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.CampainConfigurationTypeId);

            builder.HasMany(x => x.ClientCampains)
                .WithOne(x => x.Campain)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.CampainId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
