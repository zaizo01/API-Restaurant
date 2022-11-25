using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockApp.Core.Application.Dtos.Account;
using StockApp.Core.Application.Enums;
using StockApp.Core.Application.Interfaces.Services;
using StockApp.Core.Application.ViewModels.User;

namespace StockApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _accountService.AuthenticateAsync(request));
        }

        [HttpPost("RegisterAdminUser")]
        public async Task<IActionResult> RegisterAdminAsync(RegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.RegisterUserAsync(request, origin, Roles.Admin));
        }

        [HttpPost("RegisterWaiterUser")]
        public async Task<IActionResult> RegisterWaiterAsync(RegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.RegisterUserAsync(request, origin, Roles.Waiter));
        }

    }
}

