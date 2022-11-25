using StockApp.Core.Application.Dtos.Account;
using StockApp.Core.Application.Enums;
using StockApp.Core.Application.ViewModels.User;
using System.Threading.Tasks;

namespace StockApp.Core.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegisterResponse> RegisterUserAsync(RegisterRequest request, string origin, Roles tyoeOfUser);
        

    }
}