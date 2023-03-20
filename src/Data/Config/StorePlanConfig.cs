using Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Config
{
    public class StorePlanConfig : IEntityTypeConfiguration<StorePlan>
    {
        public void Configure(EntityTypeBuilder<StorePlan> builder)
        {
            builder.ToTable("StorePlans");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType("varchar(100)");

            builder.HasMany(x => x.Stores)
                .WithOne(x => x.StorePlan)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.StorePlanId);
        }
    }

}
