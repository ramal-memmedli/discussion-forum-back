using Debat.Core.Application.DTOs.Account;
using Debat.Core.Application.Services;
using Debat.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Debat.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtService _jwtService;

        public AccountController(UserManager<AppUser> userManager,
                                 RoleManager<IdentityRole> roleManager,
                                 IJwtService jwtService) 
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDTO loginUser)
        {
            AppUser? appUser = await _userManager.FindByNameAsync(loginUser.Username);
            if (appUser == null) return NotFound();

            if (!await _userManager.CheckPasswordAsync(appUser, loginUser.Password)) return Unauthorized();

            string token = _jwtService.GenerateToken(appUser);

            return Ok(token);
        }
    }
}
