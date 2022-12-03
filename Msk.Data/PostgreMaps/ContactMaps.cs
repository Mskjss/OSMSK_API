using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Msk.Domain.Users;


namespace Msk.Data.PostgreMaps
{
    public class ContactMaps : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contact");
            builder.HasKey("ID");
            builder.Property(contact => contact.UserID)
                .HasColumnName("ID");

            builder.Property(contact => contact.Cell)
                .HasColumnName("Cell")
                .IsRequired();

            builder.Property(contact => contact.Cell)
               .HasColumnName("Cell")
               .HasMaxLength(50)
               .HasColumnType("varchar")
               .IsRequired();


        }
    }
}
