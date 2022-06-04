using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using RPGInfo.Web.Models;

namespace RPGInfo.Web.Pages.User
{
    public class UserDetailModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        public UserDetailModel(UserManager<ApplicationUser> userManager)
        {
            userManager = _userManager;
        }

        public IActionResult Create()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostCreate(Models.User user)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new ApplicationUser
                {
                    UserName = user.Name,
                    Email = user.Email
                };

                IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);

                if (!result.Succeeded)
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return RedirectToPage(user);
        }


    }
}
