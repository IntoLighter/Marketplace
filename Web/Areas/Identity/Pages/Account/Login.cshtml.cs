#nullable disable

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

namespace Web.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        public LoginModel()
        {
        }

        [BindProperty] public InputModel Input { get; set; }

        [BindProperty] public string ReturnUrl { get; set; }

        [TempData] public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Номер телефона необходим")]
            [DataType(DataType.PhoneNumber)]
            [StringLength(10, MinimumLength = 10, ErrorMessage = "Номер телефона должен иметь 10 цифр")]
            public string PhoneNumber { get; set; }
        }

        public async Task OnGetAsync(string returnUrl)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("VerifyCode", new { Input.PhoneNumber, ReturnUrl });
            }

            return Page();
        }
    }
}
