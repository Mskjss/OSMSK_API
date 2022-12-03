using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Msk.Domain.Users;

namespace Msk.Data.PostgreMaps
{
    public class AdressMaps : IEntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> builder)
        {
            builder.ToTable("Adress");

            builder.HasKey("ID");
            builder.Property(adress => adress.UserID)
                .HasColumnName("ID");

            builder.Property(adress => adress.Postcode)
                .HasColumnName("Postcode")
                .IsRequired();

            builder.Property(adress => adress.City)
               .HasColumnName("City")
               .HasMaxLength(50)
               .HasColumnType("varchar")
               .IsRequired();

            builder.Property(adress => adress.District)
              .HasColumnName("District")
              .HasMaxLength(50)
              .HasColumnType("varchar")
              .IsRequired();

            builder.Property(adress => adress.PublicPlace)
              .HasColumnName("PublicPlace")
              .HasMaxLength(50)
              .HasColumnType("varchar")
              .IsRequired();

            builder.Property(adress => adress.Number)
              .HasColumnName("Number")
              .HasMaxLength(50)
              .IsRequired();

            builder.Property(adress => adress.Complement)
              .HasColumnName("Complement")
              .HasMaxLength(50)
              .HasColumnType("varchar")
              .IsRequired();

            builder.Property(adress => adress.State)
              .HasColumnName("State")
              .HasMaxLength(50)
              .HasColumnType("varchar")
              .IsRequired();

            builder.Property(adress => adress.Country)
             .HasColumnName("Country")
             .HasMaxLength(50)
             .HasColumnType("varchar")
             .IsRequired();

            builder.Property(adress => adress.ReferencPoint)
             .HasColumnName("ReferencPoint")
             .HasMaxLength(50)
             .HasColumnType("varchar")
             .IsRequired();


        }
    }
}
