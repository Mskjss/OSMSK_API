using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Msk.Domain.Token;


namespace Msk.Data.PostgreMaps
{
    public class UserRefreshTokensMaps : IEntityTypeConfiguration<UserRefreshTokens>
    {
        public void Configure(EntityTypeBuilder<UserRefreshTokens> builder)
        {
            builder.ToTable("UserRefreshTokens");
            builder.HasKey("ID");
            builder.Property(userrefreshtokens => userrefreshtokens.Id)
                .HasColumnName("ID");

            builder.Property(userrefreshtokens => userrefreshtokens.UserName)
                .HasColumnName("UserName")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(userrefreshtokens => userrefreshtokens.RefreshToken)
               .HasColumnName("RefreshToken")
               .HasMaxLength(200)
               .HasColumnType("varchar")
               .IsRequired();

            builder.Property(userrefreshtokens => userrefreshtokens.IsActive)
              .HasColumnName("IsActive")
              .IsRequired();


        }
    }
}
