using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Msk.Domain.Users;


namespace Msk.Data.PostgreMaps
{
    public class UserMaps : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey("ID");
            builder.Property(user => user.Id)
               .HasColumnName("ID");

            builder.Property(user => user.Name)
               .HasColumnName("Name")
               .IsRequired();

            builder.Property(user => user.Password)
               .HasColumnName("Password")
               .IsRequired();

            builder.Property(user => user.Created)
               .HasColumnName("Created")
               .HasMaxLength(50)
               .IsRequired();

            builder.Property(user => user.Password)
               .HasColumnName("Password")
               .IsRequired();
            
        }
    }
}
