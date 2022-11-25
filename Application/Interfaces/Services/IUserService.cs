using Restaurant.Core.Application.Dtos.Account;
using Restaurant.Core.Application.Enums;
using Restaurant.Core.Application.ViewModels.User;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<AuthenticationResponse> LoginAsync(LoginViewModel vm);
        Task<RegisterResponse> RegisterAsync(SaveUserViewModel vm, string origin, Roles typeOfUser);
    }
}