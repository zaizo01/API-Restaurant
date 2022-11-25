using Restaurant.Core.Application.Dtos.Account;
using Restaurant.Core.Application.Enums;
using Restaurant.Core.Application.ViewModels.User;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegisterResponse> RegisterUserAsync(RegisterRequest request, string origin, Roles tyoeOfUser);
        

    }
}