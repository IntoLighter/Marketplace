// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Threading.Tasks;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Web.Areas.Identity.Pages.Account
{
    [Authorize]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LogoutModel(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnGet(string returnUrl)
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
