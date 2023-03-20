using Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
              .IsRequired()
              .HasColumnType("varchar(200)");

            builder.Property(x => x.Login)
              .IsRequired()
              .HasColumnType("varchar(400)");


            builder.Property(x => x.Email)
              .IsRequired()
              .HasColumnType("varchar(400)");


            builder.Property(x => x.Password)
              .IsRequired()
              .HasColumnType("varchar(200)");

            builder.HasOne(x => x.UserType)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.UserTypeId)
                .HasPrincipalKey(x => x.Id);

            builder.HasOne(x => x.Store)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.StoreId)
                .HasPrincipalKey(x => x.Id);

            builder.HasMany(x => x.Tickets)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .HasPrincipalKey(x => x.Id);


        }
    }

}
