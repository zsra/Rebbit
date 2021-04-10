using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rebbit.Core.Entities.Base;

namespace Rebbit.Infrastructure.Configs
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("ApplicationUsers");

            builder.Property(i => i.Email).IsRequired().HasMaxLength(100);
            builder.Property(i => i.UserName).IsRequired().HasMaxLength(40);
        }
    }
}
