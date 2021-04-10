using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rebbit.Core.Entities;

namespace Rebbit.Infrastructure.Configs
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.Property(i => i.Id).UseIdentityColumn().IsRequired();
            builder.Property(ci => ci.JoinedAt).IsRequired();
            builder.Property(ci => ci.ProfilePictureUrl).IsRequired();
            builder.Property(ci => ci.Username).IsRequired().HasMaxLength(50);
        }
    }
}
