using System.ComponentModel.DataAnnotations;
using System.Net.Security;
using Infrastructure.Authentication;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Verify.V2.Service;
using Twilio.Types;

namespace Web.Areas.Identity.Pages.Account;

public class VerifyCodeModel : PageModel
{
    private readonly TwilioVerificationCredentials _verificationCredentials;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public VerifyCodeModel(IOptions<TwilioVerificationCredentials> verificationCredentials,
        SignInManager<AppUser> signInManager)
    {
        _userManager = signInManager.UserManager;
        _signInManager = signInManager;
        _verificationCredentials = verificationCredentials.Value;
    }

    [BindProperty] public InputModel Input { get; set; }
    [BindProperty] public string ReturnUrl { get; set; }
    [BindProperty] public string PhoneNumber { get; set; }
    [TempData] private string ErrorMessage { get; set; }

    public class InputModel
    {
        [Required(ErrorMessage = "Код необходим")]
        public string Code { get; set; }
    }

    public async Task OnGetAsync(string phoneNumber, string returnUrl)
    {
        if (!string.IsNullOrEmpty(ErrorMessage))
        {
            ModelState.AddModelError(string.Empty, ErrorMessage);
        }
        else
        {
            var msg = await VerificationResource.CreateAsync(
                to: $"+7{phoneNumber}",
                channel: "sms",
                pathServiceSid: _verificationCredentials.VerificationSId
            );
        }

        ReturnUrl = returnUrl;
        PhoneNumber = phoneNumber;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            var msg = await VerificationCheckResource.CreateAsync(
                to: $"+7{PhoneNumber}",
                code: Input.Code,
                pathServiceSid: _verificationCredentials.VerificationSId
            );

            if (msg.Valid == false)
            {
                throw new Exception("Sms code VerificationCheck is invalid");
            }

            var user = await _userManager.FindByNameAsync(PhoneNumber);
            if (user == null)
            {
                user = new AppUser
                {
                    UserName = PhoneNumber,
                    PhoneNumber = PhoneNumber
                };
                var result = await _userManager.CreateAsync(user);
                if (!result.Succeeded)
                {
                    var error = ""; 
                    var errors = result.Errors.ToList();
                    for (var i = 0; i < errors.Count; i++)
                    {
                        error += $"{i + 1}: {errors[i].Description}\n";
                    }
                    throw new Exception($"Can't create new user: \n{error}");
                }
            }

            await _signInManager.SignInAsync(user, false);

            return Redirect(ReturnUrl);
        }

        return Page();
    }
}
