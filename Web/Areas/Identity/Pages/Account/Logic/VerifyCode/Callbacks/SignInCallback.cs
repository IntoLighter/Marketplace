using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Web.Areas.Identity.Pages.Account.Logic.VerifyCode.Callbacks;

public class SignInCallback : ISuccessCallback
{
    public static ISuccessCallback Instance { get; } = new SignInCallback();
    private SignInCallback() {}

    public async Task CallAsync(AppUser user, SignInManager<AppUser> signInManager)
    {
        var result = await signInManager.UserManager.CreateAsync(user);
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

        await signInManager.SignInAsync(user, false);
    }
}
