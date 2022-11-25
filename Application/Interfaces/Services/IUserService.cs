using StockApp.Core.Application.Dtos.Account;
using StockApp.Core.Application.Enums;
using StockApp.Core.Application.ViewModels.User;
using System.Threading.Tasks;

namespace StockApp.Core.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<AuthenticationResponse> LoginAsync(LoginViewModel vm);
        Task<RegisterResponse> RegisterAsync(SaveUserViewModel vm, string origin, Roles typeOfUser);
    }
}