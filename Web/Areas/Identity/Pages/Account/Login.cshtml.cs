using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Resources;
using System.Threading.Channels;
using System.Threading.Tasks;
using Infrastructure.Authentication;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Verify.V2.Service;
using Web.Areas.Identity.Pages.Account.Logic.VerifyCode;

namespace Web.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginModel(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty] public InputModel Input { get; set; }

        [BindProperty] public string? ReturnUrl { get; set; }


        public class InputModel
        {
            [Display(Name = "Номер телефона")]
            [Required(ErrorMessage = "Номер телефона необходим")]
            [Phone(ErrorMessage = "Некорректный номер телефона")]
            [StringLength(10, MinimumLength = 10, ErrorMessage = "Должен иметь 10 цифр")]
            public string PhoneNumber { get; set; }
        }

        public async Task OnGetAsync(string? returnUrl)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("VerifyCode", new
                {
                    phoneNumber = Input.PhoneNumber,
                    returnUrl = ReturnUrl,
                    callbackType = SuccessCallbackType.SignInCallback
                });
            }

            return Page();
        }
    }
}
