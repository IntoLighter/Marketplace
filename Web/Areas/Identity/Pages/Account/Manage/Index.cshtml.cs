using System.ComponentModel.DataAnnotations;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Areas.Identity.Pages.Account.Logic.VerifyCode;

namespace Web.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public IndexModel(
            SignInManager<AppUser> signInManager)
        {
            _userManager = signInManager.UserManager;
            _signInManager = signInManager;
        }

        [TempData] public string? StatusMessage { get; set; }

        [BindProperty] public InputModel Input { get; set; } = null!;

        public class InputModel
        {
            [Phone(ErrorMessage = "Некорректный номер телефона")]
            [Display(Name = "Номер телефона")]
            [Required(ErrorMessage = "Номер телефона необходим")]
            public string PhoneNumber { get; set; } = string.Empty;
        }

        private async Task LoadAsync(AppUser user)
        {
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Input = new InputModel
            {
                PhoneNumber = phoneNumber
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var phoneNumber = user.PhoneNumber!;

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            if (Input.PhoneNumber != phoneNumber)
            {
                return RedirectToPage("../VerifyCode", new
                {
                    phoneNumber = Input.PhoneNumber,
                    returnUrl = Request.GetEncodedUrl(),
                    callbackType = SuccessCallbackType.SaveAccountChangesCallback
                });
            }

            return Page();
        }
    }
}
