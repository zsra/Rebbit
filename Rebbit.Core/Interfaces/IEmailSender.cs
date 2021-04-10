using System.Threading.Tasks;

namespace Rebbit.Core.Interfaces
{
    public interface IEmailSender
    {
        ValueTask SendEmailAsync(string email, string subject, string message);
    }
}
