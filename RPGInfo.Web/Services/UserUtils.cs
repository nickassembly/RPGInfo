using System.Security.Claims;

namespace RPGInfo.Web.Services
{
    public static class UserUtils
    {
        public static string GetLoggedInUser(ClaimsPrincipal currentUser)
        {
            var currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            return currentUserId;
        }
    }
}
