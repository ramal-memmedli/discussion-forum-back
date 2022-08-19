using BusinessLayer.Services;
using Common.Helpers;
using DataAccessLayer.Models;
using ForumMVC.ViewModels.AccountVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using static Common.Helpers.Enums;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Routing;

namespace ForumMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserImageService _userImageService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, IUserImageService userImageService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userImageService = userImageService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(controllerName: "Home", actionName: "Index");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            AppUser newUser = new AppUser()
            {
                Name = registerVM.Name,
                Surname = registerVM.Surname,
                UserName = registerVM.Username,
                Email = registerVM.Email,
                LevelId = 1
            };

            IdentityResult result = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View(registerVM);
                }
            }

            UserImage userProfileImage = new UserImage();

            userProfileImage.AppUserId = newUser.Id;
            userProfileImage.ImageId = 1;
            userProfileImage.Target = "profile";

            try
            {
                await _userImageService.Create(userProfileImage);
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");
            }

            if ((await _userManager.GetUsersInRoleAsync(Enums.Roles.Admin.ToString())).Count == 0)
            {
                await _userManager.AddToRoleAsync(newUser, Enums.Roles.Admin.ToString());
            }
            else
            {
                await _userManager.AddToRoleAsync(newUser, Enums.Roles.User.ToString());
            }

            string token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);

            string route = Url.Action("ConfirmEmail", "Account", new { userId = newUser.Id, token }, HttpContext.Request.Scheme);


            MimeMessage message = new MimeMessage();

            message.From.Add(new MailboxAddress("Discussion Forum", "discussion.forum.app.code.2022@gmail.com"));
            message.To.Add(new MailboxAddress(newUser.Name, newUser.Email));
            message.Subject = "Confirm email";
            message.Body = new TextPart("plain")
            {
                Text = route
            };

            using(SmtpClient client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("discussion.forum.app.code.2022@gmail.com", "yzhqccxoubcbgubf");
                client.Send(message);
                client.Disconnect(true);
            }

            return RedirectToAction(actionName: "login", controllerName: "account");
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");
            }

            AppUser user = await _userManager.FindByIdAsync(userId);

            if (user is null)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");
            }

            await _userManager.ConfirmEmailAsync(user, token);

            return RedirectToAction(controllerName: "account", actionName: "login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(controllerName: "Home", actionName: "Index");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser user = await _userManager.FindByNameAsync(loginVM.Username);

            if (user is null)
            {
                ModelState.AddModelError("", "Account doesn't exists");
                return View();
            }

            SignInResult result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.IsPersistent, true);

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Account locked out, please try again later");
                return View();
            }

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or password is wrong");
                return View();
            }

            return RedirectToAction(controllerName: "home", actionName: "index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> EditAccount()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            EditVM editVM = new EditVM();
            editVM.Name = user.Name;
            editVM.Surname = user.Surname;
            editVM.About = user.About;

            return View(editVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> EditAccount(EditVM editVM)
        {
            if (!ModelState.IsValid)
            {
                return View(editVM);
            }

            AppUser you = await _userManager.FindByNameAsync(User.Identity.Name);

            you.Name = editVM.Name;
            you.Surname = editVM.Surname;
            you.About = editVM.About;
            IdentityResult result = await _userManager.UpdateAsync(you);

            if (result.Succeeded)
            {
                return RedirectToAction(actionName: "index", controllerName: "user", new { id = you.UserName });
            }

            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
                return View(editVM);
            }

            return View(editVM);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM passwordVM)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            IdentityResult result = await _userManager.ChangePasswordAsync(user, passwordVM.CurrentPassword, passwordVM.NewPassword);

            if (result.Succeeded)
            {
                await Logout();

                MimeMessage message = new MimeMessage();

                message.From.Add(new MailboxAddress("Discussion Forum", "discussion.forum.app.code.2022@gmail.com"));
                message.To.Add(new MailboxAddress(user.Name, user.Email));
                message.Subject = "Security alert";
                message.Body = new TextPart("plain")
                {
                    Text = "Your forum password was changed"
                };

                using (SmtpClient client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("discussion.forum.app.code.2022@gmail.com", "yzhqccxoubcbgubf");
                    client.Send(message);
                    client.Disconnect(true);
                }

                return RedirectToAction(actionName: "login", controllerName: "account");
            }

            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
                return View();
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(controllerName: "account", actionName: "login");
        }

        [HttpGet]
        public async Task CreateRoles()
        {
            foreach (string role in Enum.GetNames(typeof(Enums.Roles)))
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
