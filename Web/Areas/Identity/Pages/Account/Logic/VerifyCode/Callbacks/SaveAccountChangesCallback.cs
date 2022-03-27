using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Web.Areas.Identity.Pages.Account.Logic.VerifyCode.Callbacks;

public class SaveAccountChangesCallback : ISuccessCallback
{
    public static ISuccessCallback Instance { get; } = new SaveAccountChangesCallback();
    private SaveAccountChangesCallback() {}

    public async Task CallAsync(AppUser user, SignInManager<AppUser> signInManager)
    {
        await signInManager.RefreshSignInAsync(user);
    }
}
