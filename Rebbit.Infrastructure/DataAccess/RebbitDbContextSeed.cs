using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Rebbit.Infrastructure.DataAccess
{
    public class RebbitDbContextSeed
    {
        private static readonly string LORUM_IPSUM = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla tempus hendrerit neque at porttitor. Vestibulum elementum velit odio, at volutpat enim euismod eu.";

        public static async Task SeedAsync(RebbitDbContext context,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
#if DEBUG
#endif
            }
            catch (Exception e)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<RebbitDbContext>();
                    log.LogError(e.Message);
                    await SeedAsync(context, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }
    }
}
