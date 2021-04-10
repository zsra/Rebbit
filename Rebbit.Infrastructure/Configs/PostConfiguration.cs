using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rebbit.Core.Entities;

namespace Rebbit.Infrastructure.Configs
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");

            builder.Property(i => i.Id).UseIdentityColumn().IsRequired();
            builder.Property(ci => ci.Body).IsRequired();
            builder.Property(ci => ci.CreatedAt).IsRequired();
            builder.Property(ci => ci.Title).IsRequired().HasMaxLength(50);
        }
    }
}
