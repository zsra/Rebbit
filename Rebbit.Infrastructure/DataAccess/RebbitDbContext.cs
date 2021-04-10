using Microsoft.EntityFrameworkCore;
using Rebbit.Core.Entities;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Rebbit.Infrastructure.DataAccess
{
    public class RebbitDbContext : DbContext
    {
        public RebbitDbContext([NotNullAttribute] DbContextOptions<RebbitDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public  DbSet<Comment> Comments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ConfigureModelBuilder(builder);
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ConfigureModelBuilder(ModelBuilder builder)
        {
            builder.Entity<Post>().OwnsOne(p => p.RatingInfo);
            builder.Entity<Comment>().OwnsOne(p => p.RatingInfo);
            builder.Entity<Post>().OwnsOne(p => p.EditedInfo);
            builder.Entity<Comment>().OwnsOne(p => p.EditedInfo);
        }
    }
}
