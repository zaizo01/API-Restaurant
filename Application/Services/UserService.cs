using AutoMapper;
using StockApp.Core.Application.Dtos.Account;
using StockApp.Core.Application.DTOs.Email;
using StockApp.Core.Application.Enums;
using StockApp.Core.Application.Interfaces.Repositories;
using StockApp.Core.Application.Interfaces.Services;
using StockApp.Core.Application.ViewModels.User;
using StockApp.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApp.Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public UserService(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<AuthenticationResponse> LoginAsync(LoginViewModel vm)
        {
            AuthenticationRequest loginRequest = _mapper.Map<AuthenticationRequest>(vm);
            AuthenticationResponse userResponse = await _accountService.AuthenticateAsync(loginRequest);
            return userResponse;
        }


        public async Task<RegisterResponse> RegisterAsync(SaveUserViewModel vm, string origin, Roles typeOfUser)
        {
            RegisterRequest registerRequest = _mapper.Map<RegisterRequest>(vm);
            return await _accountService.RegisterUserAsync(registerRequest, origin, typeOfUser);
        }
    }
}
