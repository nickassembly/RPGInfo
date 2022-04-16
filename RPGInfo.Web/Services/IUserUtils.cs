using System.Security.Claims;

namespace RPGInfo.Web.Services
{
    public interface IUserUtils
    {
        string GetLoggedInUser(ClaimsPrincipal currentUser);
    }
}
