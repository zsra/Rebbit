using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rebbit.Core.Entities;

namespace Rebbit.Infrastructure.Configs
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.Property(i => i.Id).UseIdentityColumn().IsRequired();
            builder.Property(ci => ci.Name).IsRequired();
            builder.Property(ci => ci.Permissions).IsRequired();
        }
    }
}
