using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rebbit.Core.Entities;

namespace Rebbit.Infrastructure.Configs
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Groups");

            builder.Property(i => i.Id).UseIdentityColumn().IsRequired();
            builder.Property(ci => ci.Name).IsRequired().HasMaxLength(24);
            builder.Property(ci => ci.CreatedAt).IsRequired();
            builder.Property(ci => ci.CreatorId).IsRequired();
            builder.Property(ci => ci.ModeratorIds).IsRequired();
            builder.Property(ci => ci.Description).IsRequired().HasMaxLength(100);
        }
    }
}
