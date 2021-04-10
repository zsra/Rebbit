using System.Threading.Tasks;

namespace Rebbit.Core.Interfaces.Services
{
    public interface ITokenClaimsService
    {
        ValueTask<string> GetTokenAsync(string userName);
    }
}
