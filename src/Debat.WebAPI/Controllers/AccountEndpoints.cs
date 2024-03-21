using Debat.Core.Application.DTOs.Account;
using Debat.Core.Application.Services;
using Debat.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Debat.WebAPI.Controllers
{
    public static class AccountEndpoints
    {
        public static void MapAccountEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/account");
            group.MapPost("/login", Login).WithName(nameof(Login));
        }


        public static async Task<IResult> Login([FromBody] LoginDTO loginUser,
                                                UserManager<AppUser> userManager,
                                                IJwtService jwtService)
        {
            AppUser? appUser = await userManager.FindByNameAsync(loginUser.Username);
            if (appUser == null) return Results.NotFound();

            if (!await userManager.CheckPasswordAsync(appUser, loginUser.Password)) return Results.Unauthorized();

            string token = jwtService.GenerateToken(appUser);

            return Results.Ok(token);
        }
    }
}
