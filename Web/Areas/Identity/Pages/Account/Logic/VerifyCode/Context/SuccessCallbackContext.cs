using Web.Areas.Identity.Pages.Account.Logic.VerifyCode.Callbacks;

namespace Web.Areas.Identity.Pages.Account.Logic.VerifyCode.Context;

public class SuccessCallbackContext : ISuccessCallbackContext
{
    private readonly ISuccessCallback _saveAccountChangesCallback = SaveAccountChangesCallback.Instance;
    private readonly ISuccessCallback _signInCallback = SaveAccountChangesCallback.Instance;

    public ISuccessCallback GetCallback(SuccessCallbackType type)
    {
        return type switch
        {
            SuccessCallbackType.SaveAccountChangesCallback => _saveAccountChangesCallback,
            SuccessCallbackType.SignInCallback => _signInCallback,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}
