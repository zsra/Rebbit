using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rebbit.Core.Entities;

namespace Rebbit.Infrastructure.Configs
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");

            builder.Property(i => i.Id).UseIdentityColumn().IsRequired();
            builder.Property(ci => ci.Body).IsRequired();
            builder.Property(ci => ci.CreatedAt).IsRequired();
        }
    }
}
