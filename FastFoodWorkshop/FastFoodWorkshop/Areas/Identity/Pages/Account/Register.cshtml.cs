namespace FastFoodWorkshop.Areas.Identity.Pages.Account
{
    using Common.StringConstants;
    using Common.CustomValidations;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;
    using Microsoft.AspNetCore.Http;
    using System.IO;
    using Microsoft.AspNetCore.Hosting;

    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<FastFoodUser> _signInManager;
        private readonly UserManager<FastFoodUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IHostingEnvironment environment;

        public RegisterModel(
            IHostingEnvironment environment,
            UserManager<FastFoodUser> userManager,
            SignInManager<FastFoodUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = CommonStrings.FirstName, Prompt = CommonStrings.FirstName)]
            [DataType(DataType.Text)]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = CommonStrings.LastName, Prompt = CommonStrings.LastName)]
            [DataType(DataType.Text)]
            public string LastName { get; set; }

            [Required]
            [Display(Name = CommonStrings.UserName, Prompt = CommonStrings.UserName)]
            [DataType(DataType.Text)]
            public string Username { get; set; }

            [Required]
            [Display(Name = CommonStrings.Address, Prompt = CommonStrings.Address)]
            [DataType(DataType.Text)]
            public string Address { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [DateRestrictToday(ErrorMessage = ErrorMessages.DateCannotBeAfterToday)]
            public DateTime DateOfBirth { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = CommonStrings.Email, Prompt = CommonStrings.EmailExample)]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = ErrorMessages.PasswordLength)]
            [DataType(DataType.Password)]
            [Display(Name = CommonStrings.Password, Prompt = CommonStrings.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = CommonStrings.ConfirmPassword, Prompt = CommonStrings.ConfirmPassword)]
            [Compare(CommonStrings.Password, ErrorMessage = ErrorMessages.PasswordsDoNotMatch)]
            public string ConfirmPassword { get; set; }

            [BindProperty]
            public IFormFile Picture { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            IFormFile formFile = null;

            if (HttpContext.Request.Form.Files.Count > 0)
            {
                formFile = HttpContext.Request.Form.Files[0];
            }

            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new FastFoodUser
                {
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    UserName = Input.Username,
                    Address = Input.Address,
                    BirthDate = Input.DateOfBirth,
                    Email = Input.Email,
                };

                if (formFile != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await formFile.CopyToAsync(memoryStream);
                        user.Picture = memoryStream.ToArray();
                    }
                }

                var result = await _userManager.CreateAsync(user, Input.Password);
                await this._userManager.AddToRoleAsync(user, CommonStrings.UserRole);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
