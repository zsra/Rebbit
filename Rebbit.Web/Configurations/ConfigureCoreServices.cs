using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rebbit.Core.Interfaces;
using Rebbit.Core.Interfaces.Services;
using Rebbit.Core.Services;
using Rebbit.Infrastructure.DataAccess;
using Rebbit.Infrastructure.Logging;

namespace Rebbit.Web.Configurations
{
    public static class ConfigureCoreServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IFeedService, FeedService>();

            return services;
        }
    }
}
