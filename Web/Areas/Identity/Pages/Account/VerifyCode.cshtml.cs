using System.ComponentModel.DataAnnotations;
using System.Net.Security;
using Infrastructure.Authentication;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Verify.V2;
using Twilio.Rest.Verify.V2.Service;
using Twilio.Types;
using Web.Areas.Identity.Pages.Account.Logic.VerifyCode;
using Web.Areas.Identity.Pages.Account.Logic.VerifyCode.Context;

namespace Web.Areas.Identity.Pages.Account;

public class VerifyCodeModel : PageModel
{
    private readonly TwilioVerificationCredentials _verificationCredentials;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ISuccessCallbackContext _callbackContext;
    private readonly ILogger<VerifyCodeModel> _logger;

    public VerifyCodeModel(IOptions<TwilioVerificationCredentials> verificationCredentials,
        UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ISuccessCallbackContext callbackContext,
        ILogger<VerifyCodeModel> logger)
    {
        _signInManager = signInManager;
        _callbackContext = callbackContext;
        _logger = logger;
        _userManager = signInManager.UserManager;
        _verificationCredentials = verificationCredentials.Value;
    }

    [BindProperty] public InputModel Input { get; set; }
    [BindProperty] public string? ReturnUrl { get; set; }
    [BindProperty] public string PhoneNumber { get; set; }
    [BindProperty] public SuccessCallbackType CallbackType { get; set; }

    public class InputModel
    {
        [Required(ErrorMessage = "Код необходим")]
        [Display(Name = "Код подтверждения")]
        [Phone(ErrorMessage = "Некорректный код подтверждения")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Должен состоять из 4 цифр")]
        public string Code { get; set; }
    }

    public async Task OnGetAsync(string phoneNumber, string? returnUrl, SuccessCallbackType callbackType)
    {
        var msg = await VerificationResource.CreateAsync(
            to: $"+7{phoneNumber}",
            channel: "sms",
            pathServiceSid: _verificationCredentials.VerificationSId
        );
        _logger.LogInformation("Message SId: {Id}", msg.Sid);

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

        if (msg.Valid == false)
        {
            throw new Exception("Sms code VerificationCheck is invalid");
        }

        var user = await _userManager.FindByNameAsync(PhoneNumber) ?? new AppUser
        {
            UserName = PhoneNumber,
            PhoneNumber = PhoneNumber
        };
        await _callbackContext.GetCallback(CallbackType).CallAsync(user, _signInManager);

        return Redirect(ReturnUrl ?? Url.Content("~/"));
    }
}
