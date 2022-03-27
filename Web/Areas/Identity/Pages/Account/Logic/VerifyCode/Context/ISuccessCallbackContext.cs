using Web.Areas.Identity.Pages.Account.Logic.VerifyCode.Callbacks;

namespace Web.Areas.Identity.Pages.Account.Logic.VerifyCode.Context;

public interface ISuccessCallbackContext
{
    ISuccessCallback GetCallback(SuccessCallbackType type);
}
