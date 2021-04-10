using Rebbit.Core.Entities;
using Rebbit.Core.ValueObject;
using System.Threading.Tasks;

namespace Rebbit.Core.Interfaces.Services
{
    public interface IUserService
    {
        ValueTask<User> SignUp(SignUpData signUpData);
        ValueTask SignIn(string email, string password);
        ValueTask<User> GetUserById( int id);
    }
}
