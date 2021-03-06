using System.ComponentModel.DataAnnotations;
using Domain;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Twilio.Rest.Verify.V2.Service;
using Web.Areas.Identity.Pages.Account.Logic.VerifyCode;

namespace Web.Areas.Identity.Pages.Account;

public class VerifyCodeModel : PageModel
{
    private readonly ILogger<VerifyCodeModel> _logger;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly TwilioVerificationCredentials _verificationCredentials;

    public VerifyCodeModel(IOptions<TwilioVerificationCredentials> verificationCredentials,
        UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
        ILogger<VerifyCodeModel> logger)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _logger = logger;
        _verificationCredentials = verificationCredentials.Value;
    }

    [BindProperty] public InputModel Input { get; set; } = null!;
    [BindProperty] public string? ReturnUrl { get; set; }
    [BindProperty] public string PhoneNumber { get; set; } = string.Empty;
    [BindProperty] public SuccessCallbackType CallbackType { get; set; }

    public async Task OnGetAsync(string phoneNumber, string? returnUrl, SuccessCallbackType callbackType)
    {
        var msg = await VerificationResource.CreateAsync(
            to: $"+7{phoneNumber}",
            channel: "sms",
            pathServiceSid: _verificationCredentials.VerificationSId
        );
        _logger.LogInformation("Sent sms verification, message SId: {Id}", msg.Sid);

        CallbackType = callbackType;
        ReturnUrl = returnUrl;
        PhoneNumber = phoneNumber;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        var msg = await VerificationCheckResource.CreateAsync(
            to: $"+7{PhoneNumber}",
            code: Input.Code,
            pathServiceSid: _verificationCredentials.VerificationSId
        );

        if (msg.Valid == false) throw new Exception("Sms code VerificationCheck is invalid");

        AppUser? user;
        switch (CallbackType)
        {
            case SuccessCallbackType.SignInCallback:
                user = await _userManager.FindByNameAsync(PhoneNumber);
                if (user == null)
                {
                    user = new AppUser
                    {
                        UserName = PhoneNumber,
                        PhoneNumber = PhoneNumber
                    };

                    var result = await _signInManager.UserManager.CreateAsync(user);
                    if (!result.Succeeded)
                    {
                        var error = "";
                        var errors = result.Errors.ToList();
                        for (var i = 0; i < errors.Count; i++) error += $"{i + 1}: {errors[i].Description}\n";

                        throw new Exception($"Can't create new user: \n{error}");
                    }
                }

                await _signInManager.SignInAsync(user, false);
                break;
            case SuccessCallbackType.SaveAccountChangesCallback:
                user = await _userManager.GetUserAsync(User);
                await _userManager.SetPhoneNumberAsync(user, PhoneNumber);
                await _userManager.SetUserNameAsync(user, PhoneNumber);
                await _signInManager.RefreshSignInAsync(user);
                break;
        }

        return Redirect(ReturnUrl ?? Url.Content("~/"));
    }

    public class InputModel
    {
        [Required(ErrorMessage = "?????? ??????????????????")]
        [Display(Name = "?????? ??????????????????????????")]
        [Phone(ErrorMessage = "???????????????????????? ?????? ??????????????????????????")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "???????????? ???????????????? ???? 4 ????????")]
        public string Code { get; set; } = string.Empty;
    }
}
