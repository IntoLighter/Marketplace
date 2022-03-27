using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Web.Areas.Identity.Pages.Account.Logic.VerifyCode.Callbacks;

public interface ISuccessCallback
{
    static ISuccessCallback Instance { get; } = null!;
    Task CallAsync(AppUser user, SignInManager<AppUser> signInManager);
}
