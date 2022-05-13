using System.ComponentModel.DataAnnotations;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Areas.Identity.Pages.Account.Logic.VerifyCode;

namespace Web.Areas.Identity.Pages.Account;

public class LoginModel : PageModel
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;

    public LoginModel(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [BindProperty] public InputModel Input { get; set; } = null!;

    [BindProperty] public string? ReturnUrl { get; set; }

    public void OnGetAsync(string? returnUrl)
    {
        ReturnUrl = returnUrl;
    }

    public IActionResult OnPostAsync()
    {
        if (ModelState.IsValid)
            return RedirectToPage("VerifyCode", new
            {
                phoneNumber = Input.PhoneNumber,
                returnUrl = ReturnUrl,
                callbackType = SuccessCallbackType.SignInCallback
            });

        return Page();
    }

    public class InputModel
    {
        [Display(Name = "Номер телефона")]
        [Required(ErrorMessage = "Номер телефона необходим")]
        [Phone(ErrorMessage = "Некорректный номер телефона")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Должен иметь 10 цифр")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}