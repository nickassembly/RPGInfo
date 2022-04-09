using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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
