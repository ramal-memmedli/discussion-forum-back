using Debat.Core.Application.Services;
using Debat.Core.Application.ViewModels;
using Debat.Core.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using MimeKit;
using MailKit.Net.Smtp;
using Debat.Core.Domain.Enums;
using Debat.Common.Helpers;

namespace Debat.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserImageService _userImageService;
        private readonly IWebHostEnvironment _environment;
        private readonly IImageService _imageService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, IUserImageService userImageService, IWebHostEnvironment environment, IImageService imageService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userImageService = userImageService;
            _environment = environment;
            _imageService = imageService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Title = "Register";

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

            using (SmtpClient client = new SmtpClient())
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
            ViewBag.Title = "Login";

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
            ViewBag.Title = "Edit account";

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


            if (editVM.ProfileImage != null)
            {
                if (!editVM.ProfileImage.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("ProfileImage", "File must be an image");
                    return View(editVM);
                }

                float fileSize = (float)editVM.ProfileImage.Length / 1024 / 1024;

                float allowedFileSize = 3;

                if (fileSize > allowedFileSize)
                {
                    ModelState.AddModelError("ProfileImage", $"File must be under {allowedFileSize}MB");
                    return View(editVM);
                }

                string? fileName = await Extensions.CreateImage(editVM.ProfileImage, _environment.WebRootPath, "UserImage");

                Image image = new Image();
                image.Name = fileName;

                try
                {
                    await _imageService.Create(image);
                }
                catch (Exception ex)
                {
                    return RedirectToAction(actionName: "notfound", controllerName: "home");
                }

                List<UserImage> userImages = await _userImageService.GetAllByUserId(you.Id);

                foreach (UserImage userImage in userImages)
                {
                    if (userImage.Target == "profile")
                    {
                        userImage.ImageId = image.Id;

                        try
                        {
                            await _userImageService.Update(userImage);
                        }
                        catch (Exception)
                        {
                            return RedirectToAction(actionName: "notfound", controllerName: "home");
                        }
                    }
                }
            }

            if (editVM.BannerImage != null)
            {
                if (!editVM.BannerImage.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("BannerImage", "File must be an image");
                    return View(editVM);
                }

                float fileSize = (float)editVM.BannerImage.Length / 1024 / 1024;

                float allowedFileSize = 3;

                if (fileSize > allowedFileSize)
                {
                    ModelState.AddModelError("BannerImage", $"File must be under {allowedFileSize}MB");
                    return View(editVM);
                }

                string? fileName = await Extensions.CreateImage(editVM.BannerImage, _environment.WebRootPath, "UserImage");

                Image image = new Image();
                image.Name = fileName;

                try
                {
                    await _imageService.Create(image);
                }
                catch (Exception ex)
                {
                    return RedirectToAction(actionName: "notfound", controllerName: "home");
                }

                List<UserImage> userImages = await _userImageService.GetAllByUserId(you.Id);

                if (userImages.Count == 2)
                {
                    foreach (UserImage userImage in userImages)
                    {
                        if (userImage.Target == "banner")
                        {
                            userImage.ImageId = image.Id;

                            try
                            {
                                await _userImageService.Update(userImage);
                            }
                            catch (Exception)
                            {
                                return RedirectToAction(actionName: "notfound", controllerName: "home");
                            }
                        }
                    }
                }
                else
                {
                    UserImage userBannerImage = new UserImage();

                    userBannerImage.AppUserId = you.Id;
                    userBannerImage.ImageId = image.Id;
                    userBannerImage.Target = "banner";

                    try
                    {
                        await _userImageService.Create(userBannerImage);
                    }
                    catch (Exception ex)
                    {
                        return RedirectToAction(actionName: "notfound", controllerName: "home");

                    }
                }


            }


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
            ViewBag.Title = "Change password";

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
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM forgotPasswordVM)
        {
            if (!ModelState.IsValid)
            {
                return View(forgotPasswordVM);
            }

            AppUser user = await _userManager.FindByEmailAsync(forgotPasswordVM.Email);

            if (user != null)
            {
                string token = await _userManager.GeneratePasswordResetTokenAsync(user);

                string route = Url.Action("resetpassword", "Account", new { userId = user.Id, token }, HttpContext.Request.Scheme);

                MimeMessage message = new MimeMessage();

                message.From.Add(new MailboxAddress("Discussion Forum", "discussion.forum.app.code.2022@gmail.com"));
                message.To.Add(new MailboxAddress(user.Name, user.Email));
                message.Subject = "Reset password";
                message.Body = new TextPart("plain")
                {
                    Text = route
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
            return View(forgotPasswordVM);

        }

        [HttpGet]
        public IActionResult ResetPassword(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");
            }

            ResetPasswordVM resetPasswordVM = new ResetPasswordVM();

            resetPasswordVM.UserId = userId;
            resetPasswordVM.Token = token;

            return View(resetPasswordVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM resetPasswordVM)
        {
            if (!ModelState.IsValid)
            {
                return View(resetPasswordVM);
            }

            AppUser user = await _userManager.FindByIdAsync(resetPasswordVM.UserId);

            if (user != null)
            {
                IdentityResult result = await _userManager.ResetPasswordAsync(user, resetPasswordVM.Token, resetPasswordVM.NewPassword);

                if (!result.Succeeded)
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View();
                }

                return RedirectToAction(controllerName: "account", actionName: "login");
            }

            return RedirectToAction(actionName: "login", controllerName: "account");
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
